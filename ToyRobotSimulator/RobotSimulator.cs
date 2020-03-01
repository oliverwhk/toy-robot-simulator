using System;

namespace ToyRobotSimulator
{
    public class RobotSimulator
    {
        private readonly IToyRobot _toyRobot;

        public RobotSimulator(IToyRobot toyRobot)
        {
            _toyRobot = toyRobot;
        }

        public string ProcessCommand(string command)
        {
            if (command.StartsWith("PLACE"))
            {
                var spaceSplits = command.Split(' ');
                var commaSplits = spaceSplits[1].Split(',');
                var x = int.Parse(commaSplits[0]);
                var y = int.Parse(commaSplits[1]);
                var direction = (Direction) Enum.Parse(typeof(Direction), commaSplits[2], true);
                _toyRobot.Place(new Position(x, y), direction);
                
                return null;
            }

            if (!_toyRobot.IsOnTable) return null;

            if (command == "REPORT")
            {
                return $"{_toyRobot.Position.X},{_toyRobot.Position.Y},{_toyRobot.Direction.ToString().ToUpper()}";
            }

            if (command == "MOVE")
            {
                _toyRobot.MoveForward();
            }
            else if (command == "LEFT")
            {
                _toyRobot.TurnLeft();
            }
            else if (command == "RIGHT")
            {
                _toyRobot.TurnRight();
            }

            return null;
        }
    }
}
