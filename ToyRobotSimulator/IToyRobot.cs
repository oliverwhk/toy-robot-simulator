namespace ToyRobotSimulator
{
    public interface IToyRobot
    {
        Position Position { get; }
        Direction Direction { get; }

        void Place(Position position, Direction direction);
        void TurnLeft();
        void TurnRight();
        void MoveForward();
    }
}