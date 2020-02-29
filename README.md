# Toy Robot Simulator

The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.

Following are available commands in the application:

- `PLACE X,Y,F`<br>
  PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.

- `MOVE`<br>
  MOVE will move the toy robot one unit forward in the direction it is currently facing.

- `LEFT`
- `RIGHT`<br>
  LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without
  changing the position of the robot.

- `REPORT`<br>
  REPORT will announce the X,Y and F of the robot.
