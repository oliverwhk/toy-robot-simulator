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

## Test Data

### Example 1

```
PLACE 0,0,NORTH
MOVE
REPORT
```

`Output: 0,1,NORTH`

### Example 2

```
PLACE 0,0,NORTH
LEFT
REPORT
```

`Output: 0,0,WEST`

### Example 3

```
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
```

`Output: 3,3,NORTH`

### Example 4

```
LEFT
MOVE
PLACE 6,1,EAST
LEFT
MOVE
PLACE 5,3,NORTH
RIGHT
MOVE
LEFT
MOVE
MOVE
REPORT
```

`Output: 5,5,NORTH`
