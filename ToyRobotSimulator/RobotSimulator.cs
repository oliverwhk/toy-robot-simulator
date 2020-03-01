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
                var placeCommand = PlaceCommand.Parse(command);
                _toyRobot.Place(placeCommand.Position, placeCommand.Direction);
                
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
