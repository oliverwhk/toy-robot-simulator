using FluentAssertions;
using Moq;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class RobotSimulatorTest
    {
        private readonly Mock<IToyRobot> _toyRobotMock;
        private readonly Mock<IPlaceCommandParser> _placeCommandParserMock;
        private readonly RobotSimulator _simulator;

        public RobotSimulatorTest()
        {
            _toyRobotMock = new Mock<IToyRobot>();
            _placeCommandParserMock = new Mock<IPlaceCommandParser>();
            _simulator = new RobotSimulator(_toyRobotMock.Object, _placeCommandParserMock.Object);
        }

        [Fact]
        public void GivenRobotOnTable_WhenProcessCommandOfMove_ShouldInvokeRobotMoveForward()
        {
            _toyRobotMock.Setup(x => x.IsOnTable).Returns(true);

            _simulator.ProcessCommand("MOVE");

            _toyRobotMock.Verify(x => x.MoveForward());
        }
        
        [Fact]
        public void GivenRobotNotOnTable_WhenProcessCommandOfMove_ThenNotInvokeRobotMoveForward()
        {
            _toyRobotMock.Setup(x => x.IsOnTable).Returns(false);

            _simulator.ProcessCommand("MOVE");

            _toyRobotMock.Verify(x => x.MoveForward(), Times.Never);
        }
        
        [Fact]
        public void GivenRobotOnTable_WhenProcessCommandOfLeft_ThenInvokeRobotTurnLeft()
        {
            _toyRobotMock.Setup(x => x.IsOnTable).Returns(true);

            _simulator.ProcessCommand("LEFT");

            _toyRobotMock.Verify(x => x.TurnLeft());
        }
        
        [Fact]
        public void GivenRobotNotOnTable_WhenProcessCommandOfLeft_ThenNotInvokeRobotTurnLeft()
        {
            _toyRobotMock.Setup(x => x.IsOnTable).Returns(false);

            _simulator.ProcessCommand("LEFT");

            _toyRobotMock.Verify(x => x.TurnLeft(), Times.Never);
        }
        
        [Fact]
        public void GivenRobotOnTable_WhenProcessCommandOfRight_ThenInvokeRobotTurnRight()
        {
            _toyRobotMock.Setup(x => x.IsOnTable).Returns(true);

            _simulator.ProcessCommand("RIGHT");

            _toyRobotMock.Verify(x => x.TurnRight());
        }
        
        [Fact]
        public void GivenRobotNotOnTable_WhenProcessCommandOfRight_ThenNotInvokeRobotTurnRight()
        {
            _toyRobotMock.Setup(x => x.IsOnTable).Returns(false);

            _simulator.ProcessCommand("RIGHT");

            _toyRobotMock.Verify(x => x.TurnRight(), Times.Never);
        }
        
        [Fact]
        public void GivenRobotOnTable_WhenProcessCommandOfReport_ThenReturnToyRobotPositionAndDirection()
        {
            _toyRobotMock.Setup(x => x.IsOnTable).Returns(true);
            _toyRobotMock.Setup(x => x.Position).Returns(new Position(2, 3));
            _toyRobotMock.Setup(x => x.Direction).Returns(Direction.South);

            var result = _simulator.ProcessCommand("REPORT");

            result.Should().Be("2,3,SOUTH");
        }
        
        [Fact]
        public void GivenRobotNotOnTable_WhenProcessCommandOfReport_ThenReturnNull()
        {
            _toyRobotMock.Setup(x => x.IsOnTable).Returns(false);

            var result = _simulator.ProcessCommand("REPORT");

            result.Should().BeNull();
        }

        [Fact]
        public void ProcessCommandOfPlaceWithParserReturningPlaceCommand_ShouldInvokeRobotPlace()
        {
            const string placeCommand = "PLACE 1,2,NORTH";
            _placeCommandParserMock.Setup(x => x.Parse(placeCommand)).Returns(new PlaceCommand
            {
                Position = new Position(1, 2),
                Direction = Direction.North
            });

            _simulator.ProcessCommand(placeCommand);
            
            _toyRobotMock.Verify(x => x.Place(It.Is<Position>(p => p.X == 1 && p.Y == 2), Direction.North));
        }

        [Fact]
        public void ProcessCommandOfPlaceWithParserReturningNull_ShouldNotInvokeRobotPlace()
        {
            const string placeCommand = "PLACE1,2,123";
            _placeCommandParserMock.Setup(x => x.Parse(placeCommand)).Returns((PlaceCommand) null);

            _simulator.ProcessCommand(placeCommand);

            _toyRobotMock.Verify(x => x.Place(It.IsAny<Position>(), It.IsAny<Direction>()), Times.Never);
        }
    }
}
