using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class ToyRobotTest
    {
        [Theory]
        [MemberData(nameof(PlaceData))]
        public void PlaceAtValidPositionWithDirection_ThenSetPositionAndDirection(Position position, Direction direction)
        {
            var robot = new ToyRobot();

            robot.Place(position, direction);

            robot.Position.Should().BeEquivalentTo(position);
            robot.Direction.Should().Be(direction);
        }

        public static IEnumerable<object[]> PlaceData => new List<object[]>
        {
            new object[]{ new Position(1, 2), Direction.North},
            new object[]{ new Position(0, 0), Direction.South},
            new object[]{ new Position(5, 5), Direction.East},
        };
        
        [Theory]
        [MemberData(nameof(PlaceInvalidPositionData))]
        public void GivenRobotPositionAndLocation_WhenPlaceAtInvalidPositionWithDirection_ThenKeepOriginalPositionAndDirection(Position position, Direction direction)
        {
            var robot = new ToyRobot(1, 2, Direction.South);

            robot.Place(position, direction);

            robot.Position.Should().BeEquivalentTo(new Position(1, 2));
            robot.Direction.Should().Be(Direction.South);
        }

        public static IEnumerable<object[]> PlaceInvalidPositionData => new List<object[]>
        {
            new object[]{ new Position(-1, 2), Direction.West},
            new object[]{ new Position(6, 4), Direction.North},
            new object[]{ new Position(5, 7), Direction.North},
        };

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
