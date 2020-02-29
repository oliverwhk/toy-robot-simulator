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
    }
}
