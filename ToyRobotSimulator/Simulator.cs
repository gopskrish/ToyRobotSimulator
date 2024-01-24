using ToyRobotSimulator.enums;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator;

public interface ISimulator
{
    void Place(int x, int y, Direction facing);
    void Move();
    void Left();
    void Right();
    void Report();
}

public class Simulator : ISimulator
{
    private readonly Robot _robot;

    public Simulator(Robot robotModel)
    {
        _robot = robotModel;
    }

    public void Place(int x, int y, Direction facing)
    {
        if (x >= 0 && x <= 4 && y >= 0 && y <= 4)
        {
            _robot.X = x;
            _robot.Y = y;
            _robot.Facing = facing;
            _robot.IsPlaced = true;
        }

    }

    public void Move()
    {
        if (_robot.IsPlaced)
        {
            switch (_robot.Facing)
            {
                case Direction.NORTH:
                    if (_robot.Y < 4) _robot.Y++;
                    break;
                case Direction.SOUTH:
                    if (_robot.Y > 0) _robot.Y--;
                    break;
                case Direction.EAST:
                    if (_robot.X < 4) _robot.X++;
                    break;
                case Direction.WEST:
                    if (_robot.X > 0) _robot.X--;
                    break;
            }
        }
    }

    public void Right()
    {
        if (_robot.IsPlaced)
            _robot.Facing = (Direction)(((int)_robot.Facing + 3) % 4);
    }

    public void Left()
    {
        if (_robot.IsPlaced)
            _robot.Facing = (Direction)(((int)_robot.Facing + 1) % 4);
    }

    public void Report()
    {
        if (_robot.IsPlaced)
        {
            Console.WriteLine($"Output: {_robot.X}, {_robot.Y}, {_robot.Facing}");
        }
        else
        {
            Console.WriteLine("The Toy Robot is not yet Placed");
        }
    }
}

