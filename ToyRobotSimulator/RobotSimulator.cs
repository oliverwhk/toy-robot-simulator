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

        public void ProcessCommand(string command)
        {
            if (command == "MOVE")
            {
                _toyRobot.MoveForward();
            }
            else if (command == "LEFT")
            {
                _toyRobot.TurnLeft();
            }
        }
    }
}
