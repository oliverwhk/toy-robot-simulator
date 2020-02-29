using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class ToyRobotTest
    {
        [Fact]
        public void PlaceShouldSetPositionAndDirectionCorrectly()
        {
            var robot = new ToyRobot();

            robot.Place(new Position(1, 2), Direction.North);

            robot.Position.X.Should().Be(1);
            robot.Position.Y.Should().Be(2);
            robot.Direction.Should().Be(Direction.North);
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
        public void GivenRobotLocationAndDirection_WhenMove_ThenOneUnitForward(Position initialPosition, Direction initialDirection, Position expectedPosition)
        {
            var robot = new ToyRobot(initialPosition.X, initialPosition.Y, initialDirection);
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
    }
}
