using ToyRobotSimulator;
using ToyRobotSimulator.enums;
using ToyRobotSimulator.Models;

namespace Tests;

public class SimulatorTest
{
    private readonly Simulator _simulator;
    private readonly Robot _robot = new() { X = 3, Y = 4, Facing = Directions.NORTH };

    public SimulatorTest()
    {
        _simulator = new Simulator(_robot);
    }

    [Fact]
    public void ShouldReturnCanPlaceAsTrueIfBothPositionsAreWithinTheBoard()
    {
        var result = _simulator.CanPlace(3, 3);
        Assert.True(result);
    }

    [Fact]
    public void ShouldReturnCanPlaceAsFalseIfTheXPositionIsNotWithinTheBoard()
    {
        var result = _simulator.CanPlace(-1, 3);
        Assert.False(result);
    }

    [Fact]
    public void ShouldReturnCanPlaceAsFalseIfTheYPositionIsNotWithinTheBoard()
    {
        var result = _simulator.CanPlace(3, 5);
        Assert.False(result);
    }

    [Fact]
    public void ShouldReturnCanPlaceAsFalseIfBothPositionIsNotWithinTheBoard()
    {
        var result = _simulator.CanPlace(-1, 5);
        Assert.False(result);
    }

    [Fact]
    public void ShouldPlaceTheRobotInRightPosition()
    {
        var result = _simulator.CanPlace(-1, 5);
        Assert.False(result);
    }
}
