using ToyRobotSimulator.enums;

namespace ToyRobotSimulator;

public interface ICommandParser
{
    Commands ParseAndExecute(string commandArgument);
}

public class CommandParser : ICommandParser
{
    private readonly ISimulator _simulator;

    public CommandParser(ISimulator simulator)
    {
        _simulator = simulator;
    }

    public Commands ParseAndExecute(string commandArgument)
    {
        string arg = string.Empty;
        if(commandArgument.Contains(" "))
        {
            int spaceIndex = commandArgument.IndexOf(' ');
            arg = commandArgument.Substring(spaceIndex + 1);
            commandArgument = commandArgument.Substring(0, spaceIndex);
        }

        if (Enum.TryParse<Commands>(commandArgument, out var result))
        {
            switch (result)
            {
                case Commands.PLACE:
                    string[] args = arg.Split(',');
                    try
                    {
                        _simulator.Place(int.Parse(args[0].Trim()), int.Parse(args[1].Trim()), (Direction)Enum.Parse(typeof(Direction), args[2].Trim()));
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Error: ", exception);
                    }
                    return result;
                case Commands.MOVE:
                    _simulator.Move();
                    return result;
                case Commands.LEFT:
                    _simulator.Left();
                    return result; ;
                case Commands.RIGHT:
                    _simulator.Right();
                    return result;
                case Commands.REPORT:
                    _simulator.Report();
                    return result;
                default:
                    return result;
            }
        }

        return Commands.UNDEFINED;

    }
}


