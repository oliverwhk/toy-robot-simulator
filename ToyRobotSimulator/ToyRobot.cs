namespace ToyRobotSimulator
{

    public class ToyRobot
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        public void Place(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
