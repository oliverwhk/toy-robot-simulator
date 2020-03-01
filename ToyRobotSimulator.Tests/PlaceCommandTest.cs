using FluentAssertions;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class PlaceCommandTest
    {
        [Theory]
        [InlineData("PLACE 1,2,NORTH", 1, 2, Direction.North)]
        [InlineData("PLACE 2,4,WEST", 2, 4, Direction.West)]
        public void Parse(string command, int expectedX, int expectedY, Direction expectedDirection)
        {
            var placeCommand = PlaceCommand.Parse(command);

            var position = placeCommand.Position;
            position.X.Should().Be(expectedX);
            position.Y.Should().Be(expectedY);
            placeCommand.Direction.Should().Be(expectedDirection);
        }
    }
}
