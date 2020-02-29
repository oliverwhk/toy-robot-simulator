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
    }
}
