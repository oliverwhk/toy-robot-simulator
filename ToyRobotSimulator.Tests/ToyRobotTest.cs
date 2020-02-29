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

            robot.Place(1, 2, Direction.North);

            robot.X.Should().Be(1);
            robot.Y.Should().Be(2);
            robot.Direction.Should().Be(Direction.North);
        }
    }
}
