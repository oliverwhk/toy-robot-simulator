using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class ToyRobotTest
    {
        [Fact]
        public void PlaceAtValidPositionWithDirection_ShouldSetPositionAndDirection()
        {
            var tableMock = new Mock<ITable>();
            var robot = new ToyRobot(1, 2, Direction.East, tableMock.Object);
            var newPosition = new Position(3, 4);
            tableMock.Setup(x => x.IsValidPosition(newPosition)).Returns(true);

            robot.Place(newPosition, Direction.West);

            robot.Position.Should().BeEquivalentTo(newPosition);
            robot.Direction.Should().Be(Direction.West);
        }

        [Fact]
        public void GivenRobotPositionAndLocation_WhenPlaceAtInvalidPositionWithDirection_ThenKeepOriginalPositionAndDirection()
        {
            var tableMock = new Mock<ITable>();
            var robot = new ToyRobot(1, 2, Direction.South, tableMock.Object);
            var newPosition = new Position(-1, 4);
            tableMock.Setup(x => x.IsValidPosition(newPosition)).Returns(false);

            robot.Place(newPosition, Direction.North);

            robot.Position.Should().BeEquivalentTo(new Position(1, 2));
            robot.Direction.Should().Be(Direction.South);
        }

        [Theory]
        [InlineData(Direction.East, Direction.North)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.West, Direction.South)]
        [InlineData(Direction.North, Direction.West)]
        public void GivenRobotDirection_WhenTurnLeft_ThenFaceCorrectDirection(Direction initialDirection, Direction expectedDirection)
        {
            var robot = new ToyRobot(initialDirection);
            robot.TurnLeft();

            robot.Direction.Should().Be(expectedDirection);
        }
        
        [Theory]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        [InlineData(Direction.North, Direction.East)]
        public void GivenRobotDirection_WhenTurnRight_ThenFaceCorrectDirection(Direction initialDirection, Direction expectedDirection)
        {
            var robot = new ToyRobot(initialDirection);
            robot.TurnRight();

            robot.Direction.Should().Be(expectedDirection);
        }

        [Theory]
        [MemberData(nameof(MoveForwardData))]
        public void GivenRobotLocationAndDirection_WhenMoveForwardToValidPosition_ThenOneUnitForward(Position initialPosition, Direction initialDirection, Position expectedPosition)
        {
            var tableMock = new Mock<ITable>();
            var robot = new ToyRobot(initialPosition.X, initialPosition.Y, initialDirection, tableMock.Object);
            tableMock.Setup(x => x.IsValidPosition(It.IsAny<Position>())).Returns(true);

            robot.MoveForward();

            robot.Position.Should().BeEquivalentTo(expectedPosition);
        }

        public static IEnumerable<object[]> MoveForwardData => new List<object[]>
        {
            new object[]{ new Position(1, 1), Direction.East, new Position(2, 1) },
            new object[]{ new Position(4, 3), Direction.South, new Position(4, 2) },
            new object[]{ new Position(2, 2), Direction.West, new Position(1, 2) },
            new object[]{ new Position(1, 4), Direction.North, new Position(1, 5) },
        };

        [Fact]
        public void GivenRobotLocationAndDirection_WhenMoveForwardToInvalidPosition_ThenKeepOriginalPosition()
        {
            var tableMock = new Mock<ITable>();
            var robot = new ToyRobot(1, 0, Direction.North, tableMock.Object);
            var newPosition = new Position(6, 1);
            tableMock.Setup(x => x.IsValidPosition(newPosition)).Returns(false);

            robot.MoveForward();

            robot.Position.Should().BeEquivalentTo(new Position(1, 0));
        }
    }
}
