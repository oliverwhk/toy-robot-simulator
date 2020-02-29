using FluentAssertions;
using Moq;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class ToyRobotSimulatorTest
    {
        [Fact]
        public void ProcessCommandOfMove_ShouldInvokeToyRobotMoveForward()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);

            simulator.ProcessCommand("MOVE");

            toyRobotMock.Verify(x => x.MoveForward());
        }
        
        [Fact]
        public void ProcessCommandOfLeft_ShouldInvokeToyRobotTurnLeft()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);

            simulator.ProcessCommand("LEFT");

            toyRobotMock.Verify(x => x.TurnLeft());
        }
        
        [Fact]
        public void ProcessCommandOfRight_ShouldInvokeToyRobotTurnRight()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            var simulator = new RobotSimulator(toyRobotMock.Object);

            simulator.ProcessCommand("RIGHT");

            toyRobotMock.Verify(x => x.TurnRight());
        }
        
        [Fact]
        public void ProcessCommandOfReport_ShouldReturnToyRobotPositionAndDirection()
        {
            var simulator = new RobotSimulator(new ToyRobot(2, 3, Direction.South, new Mock<ITable>().Object));

            var result = simulator.ProcessCommand("REPORT");

            result.Should().Be("2,3,SOUTH");
        }
    }
}
