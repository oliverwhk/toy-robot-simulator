using System;

namespace ToyRobotSimulator
{
    public class PlaceCommandParser : IPlaceCommandParser
    {
        public PlaceCommand Parse(string command)
        {
            try
            {
                var spaceSplits = command.Split(' ');
                var commaSplits = spaceSplits[1].Split(',');
                var x = int.Parse(commaSplits[0]);
                var y = int.Parse(commaSplits[1]);
                var direction = (Direction)Enum.Parse(typeof(Direction), commaSplits[2], true);

                return new PlaceCommand
                {
                    Position = new Position(x, y),
                    Direction = direction
                };
            }
            catch
            {
                return null;
            }
        }
    }
}