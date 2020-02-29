namespace ToyRobotSimulator
{

    public class ToyRobot
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        public ToyRobot(Direction direction)
        {
            Direction = direction;
            Position = new Position(0, 0);
        }

        public ToyRobot() : this(Direction.East)
        {
        }

        public void Place(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }

        public void TurnLeft()
        {
            Direction newDirection;
            switch (Direction)
            {
                case Direction.East:
                    newDirection = Direction.North;
                    break;

                case Direction.South:
                    newDirection = Direction.East;
                    break;

                case Direction.West:
                    newDirection = Direction.South;
                    break;

                case Direction.North:
                    newDirection = Direction.West;
                    break;

                default:
                    newDirection = Direction;
                    break;
            }

            Direction = newDirection;
        }
    }
}
