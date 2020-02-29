namespace ToyRobotSimulator
{
    public interface IToyRobot
    {
        void Place(Position position, Direction direction);
        void TurnLeft();
        void TurnRight();
        void MoveForward();
    }
}