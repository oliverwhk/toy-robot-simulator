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
            var isRobotOnTable = _toyRobot.IsOnTable;

            if (command == "REPORT" && isRobotOnTable)
            {
                return $"{_toyRobot.Position.X},{_toyRobot.Position.Y},{_toyRobot.Direction.ToString().ToUpper()}";
            }

            if (command == "MOVE" && isRobotOnTable)
            {
                _toyRobot.MoveForward();
            }
            else if (command == "LEFT" && isRobotOnTable)
            {
                _toyRobot.TurnLeft();
            }
            else if (command == "RIGHT" && isRobotOnTable)
            {
                _toyRobot.TurnRight();
            }

            return null;
        }
    }
}
