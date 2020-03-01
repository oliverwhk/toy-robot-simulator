namespace ToyRobotSimulator
{
    public interface IPlaceCommandParser
    {
        PlaceCommand Parse(string command);
    }
}