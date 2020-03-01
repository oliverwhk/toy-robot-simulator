using System;

namespace ToyRobotSimulator
{
    public class PlaceCommand
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public static PlaceCommand Parse(string command)
        {
            var spaceSplits = command.Split(' ');
            var commaSplits = spaceSplits[1].Split(',');
            var x = int.Parse(commaSplits[0]);
            var y = int.Parse(commaSplits[1]);
            var direction = (Direction) Enum.Parse(typeof(Direction), commaSplits[2], true);

            return new PlaceCommand
            {
                Position = new Position(x, y),
                Direction = direction
            };
        }
    }
}