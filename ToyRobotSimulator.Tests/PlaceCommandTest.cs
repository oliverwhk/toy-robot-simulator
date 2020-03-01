using FluentAssertions;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class PlaceCommandTest
    {
        [Theory]
        [InlineData("PLACE 1,2,NORTH", 1, 2, Direction.North)]
        [InlineData("PLACE 2,4,WEST", 2, 4, Direction.West)]
        [InlineData("PLACE 3,5,north", 3, 5, Direction.North)]
        public void Parse_ShouldReturnPlaceCommand(string command, int expectedX, int expectedY, Direction expectedDirection)
        {
            var placeCommandParser = new PlaceCommandParser();
            var placeCommand = placeCommandParser.Parse(command);

            var position = placeCommand.Position;
            position.X.Should().Be(expectedX);
            position.Y.Should().Be(expectedY);
            placeCommand.Direction.Should().Be(expectedDirection);
        }

        [Theory]
        [InlineData("PLACE1,2,NORTH")]
        [InlineData("PLACE a,b,WEST")]
        [InlineData("PLACE 1")]
        [InlineData("PLACE 1,2")]
        [InlineData("PLACE 1,2,")]
        public void ParseWithInvalidFormat_ShouldReturnNull(string command)
        {
            var placeCommandParser = new PlaceCommandParser();
            var placeCommand = placeCommandParser.Parse(command);

            placeCommand.Should().BeNull();
        }
    }
}
