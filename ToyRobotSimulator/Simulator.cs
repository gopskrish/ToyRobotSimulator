using ToyRobotSimulator.enums;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator;

public class Simulator : ISimulator
{
    private readonly Robot _robot;
    private const int MinX = 0;
    private const int MinY = 0;
    private const int MaxX = 4;
    private const int MaxY = 4;

    public Simulator(Robot robotModel)
    {
        _robot = robotModel;
    }

    public void Place(int x, int y, Directions facing)
    {
        if (CanPlace(x, y))
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
                case Directions.NORTH:
                    Place(_robot.X, _robot.Y + 1, _robot.Facing);
                    break;
                case Directions.SOUTH:
                    Place(_robot.X, _robot.Y - 1, _robot.Facing);
                    break;
                case Directions.EAST:
                    Place(_robot.X + 1, _robot.Y, _robot.Facing);
                    break;
                case Directions.WEST:
                    Place(_robot.X - 1, _robot.Y, _robot.Facing);
                    break;
            }
        }
    }

    public void TurnDirection(Commands commands)
    {
        if (_robot.IsPlaced)
            _robot.Facing = (commands == Commands.RIGHT) ?
                (Directions)(((int)_robot.Facing + 3) % MaxX) : (Directions)(((int)_robot.Facing + 1) % MaxX);
    }

    public void GetReport()
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

    public bool CanPlace(int x, int y)
        => (x >= MinX && x <= MaxX && y >= MinY && y <= MaxY);
 
}

