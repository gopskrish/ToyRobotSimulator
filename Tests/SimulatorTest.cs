using ToyRobotSimulator;
using Moq;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.enums;

namespace Tests;

public class CommandParserTest
{
    private readonly CommandParser CommandParser;
    public CommandParserTest()
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

    [Fact]
    public void ShouldReturnCommandAsLeft()
    {
        var command = "LEFT";
        var result = CommandParser.ParseAndExecute(command);
        Assert.Equal(Commands.LEFT, result);
    }

    [Fact]
    public void ShouldReturnCommandAsRight()
    {
        var command = "RIGHT";
        var result = CommandParser.ParseAndExecute(command);
        Assert.Equal(Commands.RIGHT, result);
    }

    [Fact]
    public void ShouldReturnCommandAsPlace()
    {
        var command = "PLACE";
        var result = CommandParser.ParseAndExecute(command);
        Assert.Equal(Commands.PLACE, result);
    }

    [Fact]
    public void ShouldReturnCommandAsReport()
    {
        var command = "REPORT";
        var result = CommandParser.ParseAndExecute(command);
        Assert.Equal(Commands.REPORT, result);
    }

    [Fact]
    public void ShouldReturnCommandAsUndefinedForUnknownCommands()
    {
        var command = "PLCE";
        var result = CommandParser.ParseAndExecute(command);
        Assert.Equal(Commands.UNDEFINED, result);
    }
}
