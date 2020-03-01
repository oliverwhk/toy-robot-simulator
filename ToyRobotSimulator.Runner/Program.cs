using System;

namespace ToyRobotSimulator.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var description =
@"Toy Robot Simulator

Use any following commands:
* PLACE X,Y,F
  Place the toy robot on the table in position X,Y with facing, where F must be either NORTH, SOUTH, EAST or WEST.

* MOVE
  Move the toy robot one unit forward in the facing direction.

* LEFT
  Turn the toy robot 90 degrees left.

* RIGHT
  Turn the toy robot 90 degrees right.

* REPORT
  Display the X,Y and facing direction of the toy robot.
";
            Console.WriteLine(description);
            var toyRobot = new ToyRobot();
            var simulator = new RobotSimulator(toyRobot);

            string command;
            do
            {
                command = Console.ReadLine();
                simulator.ProcessCommand(command);
            }
            while (command != "REPORT");

            Console.WriteLine();
            Console.WriteLine($"Output: {toyRobot.Position.X},{toyRobot.Position.Y},{toyRobot.Direction.ToString().ToUpper()}");
            Console.WriteLine("Press any key to exit console.");
            Console.ReadKey();
        }
    }
}
