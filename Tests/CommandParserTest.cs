using ToyRobotSimulator;
using Moq;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.enums;

namespace Tests;

public class CommandParserTest
{
    private readonly CommandParser _commandParser;
    private readonly Mock<ISimulator> _simulatorMock;
    public CommandParserTest()
    {
        _simulatorMock = new Mock<ISimulator>();
        _commandParser = new CommandParser(_simulatorMock.Object);
    }

    [Fact]
    public void ShouldReturnCommandAsMove()
    {
        var command = "MOVE";
        var result = _commandParser.ExecuteCommand(command);
        Assert.Equal(Commands.MOVE, result);
    }

    [Fact]
    public void ShouldReturnCommandAsLeft()
    {
        var command = "LEFT";
        var result = _commandParser.ExecuteCommand(command);
        Assert.Equal(Commands.LEFT, result);
    }

    [Fact]
    public void ShouldReturnCommandAsRight()
    {
        var command = "RIGHT";
        var result = _commandParser.ExecuteCommand(command);
        Assert.Equal(Commands.RIGHT, result);
    }

    [Fact]
    public void ShouldReturnCommandAsPlace()
    {
        var command = "PLACE";
        var result = _commandParser.ExecuteCommand(command);
        Assert.Equal(Commands.PLACE, result);
    }

    [Fact]
    public void ShouldReturnCommandAsReport()
    {
        var command = "REPORT";
        var result = _commandParser.ExecuteCommand(command);
        Assert.Equal(Commands.REPORT, result);
    }

    [Fact]
    public void ShouldReturnCommandAsUndefinedForUnknownCommands()
    {
        var command = "PLCE";
        var result = _commandParser.ExecuteCommand(command);
        Assert.Equal(Commands.UNDEFINED, result);
    }

    [Fact]
    public void ShouldCallThePlaceMethodWithProperParameters()
    {
        _simulatorMock.Setup(X => X.Place(3, 4, Directions.NORTH)).Verifiable();
        var command = "PLACE 3,4,NORTH";
        var result = _commandParser.ExecuteCommand(command);
        Assert.Equal(Commands.PLACE, result);
        _simulatorMock.Verify(X => X.Place(3, 4, Directions.NORTH), Times.Once);
    }
}
