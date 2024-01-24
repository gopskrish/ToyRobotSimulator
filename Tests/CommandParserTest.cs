using ToyRobotSimulator;
using Moq;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.enums;

namespace Tests;

public class SimulatorTest
{
    private CommandParser CommandParser;
    public SimulatorTest()
    {
        CommandParser = new CommandParser(new Mock<ISimulator>().Object);
    }

    [Fact]
    public void ShouldReturnCommandAsMove()
    {
        var command = "MOVE";
        var result = CommandParser.ParseAndExecute(command);
        Assert.Equal(Commands.MOVE, result);
    }
}
