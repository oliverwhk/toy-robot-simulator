using System.Collections.Generic;

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
            var turnLeftMapping = new Dictionary<Direction, Direction>
            {
                { Direction.East, Direction.North },
                { Direction.South, Direction.East },
                { Direction.West, Direction.South },
                { Direction.North, Direction.West }
            };

            Direction = turnLeftMapping[Direction];
        }
    }
}
