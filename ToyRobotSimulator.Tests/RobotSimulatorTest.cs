using FluentAssertions;
using Moq;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class RobotSimulatorTest
    {
        [Fact]
        public void GivenRobotOnTable_WhenProcessCommandOfMove_ShouldInvokeRobotMoveForward()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);
            toyRobotMock.Setup(x => x.IsOnTable).Returns(true);

            simulator.ProcessCommand("MOVE");

            toyRobotMock.Verify(x => x.MoveForward());
        }
        
        [Fact]
        public void GivenRobotNotOnTable_WhenProcessCommandOfMove_ThenNotInvokeRobotMoveForward()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);
            toyRobotMock.Setup(x => x.IsOnTable).Returns(false);

            simulator.ProcessCommand("MOVE");

            toyRobotMock.Verify(x => x.MoveForward(), Times.Never);
        }
        
        [Fact]
        public void GivenRobotOnTable_WhenProcessCommandOfLeft_ThenInvokeRobotTurnLeft()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);
            toyRobotMock.Setup(x => x.IsOnTable).Returns(true);

            simulator.ProcessCommand("LEFT");

            toyRobotMock.Verify(x => x.TurnLeft());
        }
        
        [Fact]
        public void GivenRobotNotOnTable_WhenProcessCommandOfLeft_ThenNotInvokeRobotTurnLeft()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);
            toyRobotMock.Setup(x => x.IsOnTable).Returns(false);

            simulator.ProcessCommand("LEFT");

            toyRobotMock.Verify(x => x.TurnLeft(), Times.Never);
        }
        
        [Fact]
        public void GivenRobotOnTable_WhenProcessCommandOfRight_ThenInvokeRobotTurnRight()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);
            toyRobotMock.Setup(x => x.IsOnTable).Returns(true);

            simulator.ProcessCommand("RIGHT");

            toyRobotMock.Verify(x => x.TurnRight());
        }
        
        [Fact]
        public void GivenRobotNotOnTable_WhenProcessCommandOfRight_ThenNotInvokeRobotTurnRight()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);
            toyRobotMock.Setup(x => x.IsOnTable).Returns(false);

            simulator.ProcessCommand("RIGHT");

            toyRobotMock.Verify(x => x.TurnRight(), Times.Never);
        }
        
        [Fact]
        public void GivenRobotOnTable_WhenProcessCommandOfReport_ThenReturnToyRobotPositionAndDirection()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);
            toyRobotMock.Setup(x => x.IsOnTable).Returns(true);
            toyRobotMock.Setup(x => x.Position).Returns(new Position(2, 3));
            toyRobotMock.Setup(x => x.Direction).Returns(Direction.South);

            var result = simulator.ProcessCommand("REPORT");

            result.Should().Be("2,3,SOUTH");
        }
        
        [Fact]
        public void GivenRobotNotOnTable_WhenProcessCommandOfReport_ThenReturnNull()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);
            toyRobotMock.Setup(x => x.IsOnTable).Returns(false);

            var result = simulator.ProcessCommand("REPORT");

            result.Should().BeNull();
        }

        [Fact]
        public void ProcessCommandOfPlace_ShouldInvokeRobotPlace()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);

            simulator.ProcessCommand("PLACE 1,2,NORTH");

            toyRobotMock.Verify(x => x.Place(It.Is<Position>(p => p.X == 1 && p.Y == 2), Direction.North));
        }
    }
}
