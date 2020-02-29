using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class TableTest
    {
        [Theory]
        [MemberData(nameof(IsValidPositionData))]
        public void IsValidPosition(Position position, bool isValid)
        {
            var table = new Table();
            var isValidPosition = table.IsValidPosition(position);

            isValidPosition.Should().Be(isValid);
        }

        public static IEnumerable<object[]> IsValidPositionData => new List<object[]>
        {
            new object[]{ new Position(1, 2), true},
            new object[]{ new Position(0, 0), true},
            new object[]{ new Position(5, 5), true},
            new object[]{ new Position(-1, 2), false},
            new object[]{ new Position(6, 4), false},
            new object[]{ new Position(5, 7), false},
        };
    }
}
