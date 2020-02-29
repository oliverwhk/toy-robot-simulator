using System.Collections.Generic;

namespace ToyRobotSimulator
{

    public class ToyRobot
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }
        public ToyRobot(int x, int y, Direction direction)
        {
            Position = new Position(x, y);
            Direction = direction;
        }

        public ToyRobot(Direction direction) : this(0, 0, direction)
        {
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
            var turnLeftMapping = new Dictionary<Direction, Direction>
            {
                { Direction.East, Direction.North },
                { Direction.South, Direction.East },
                { Direction.West, Direction.South },
                { Direction.North, Direction.West }
            };

            Direction = turnLeftMapping[Direction];
        }

        public void TurnRight()
        {
            var turnRightMapping = new Dictionary<Direction, Direction>
            {
                { Direction.East, Direction.South },
                { Direction.South, Direction.West },
                { Direction.West, Direction.North },
                { Direction.North, Direction.East }
            };

            Direction = turnRightMapping[Direction];
        }

        public void MoveForward()
        {
            var newX = Position.X;
            var newY = Position.Y;

            switch (Direction)
            {
                case Direction.East:
                    newX++;
                    break;

                case Direction.South:
                    newY--;
                    break;

                case Direction.West:
                    newX--;
                    break;

                case Direction.North:
                    newY++;
                    break;
            }

            Position = new Position(newX, newY);
        }
    }
}
