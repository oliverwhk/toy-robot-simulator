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
    }
}
