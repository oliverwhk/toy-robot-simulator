using System;

namespace ToyRobotSimulator
{
    public class RobotSimulator
    {
        private readonly IToyRobot _toyRobot;
        private readonly IPlaceCommandParser _placeCommandParser;

        public RobotSimulator(IToyRobot toyRobot, IPlaceCommandParser placeCommandParser)
        {
            _toyRobot = toyRobot;
            _placeCommandParser = placeCommandParser;
        }

        public string ProcessCommand(string command)
        {
            if (command.StartsWith("PLACE"))
            {
                var placeCommand = _placeCommandParser.Parse(command);
                if (placeCommand != null)
                {
                    _toyRobot.Place(placeCommand.Position, placeCommand.Direction);
                }
                
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
