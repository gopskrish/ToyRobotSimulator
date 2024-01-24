using ToyRobotSimulator.enums;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator;

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

        if(commandArgument.Contains(' '))
        {
            int spaceIndex = commandArgument.IndexOf(' ');
            arg = commandArgument[(spaceIndex + 1)..];
            commandArgument = commandArgument[..spaceIndex];
        }

        if (Enum.TryParse<Commands>(commandArgument, out var result))
        {
            switch (result)
            {
                case Commands.PLACE:
                    string[] args = arg.Split(',');
                    try
                    {
                        _simulator.Place(int.Parse(args[0].Trim()), int.Parse(args[1].Trim()),
                            (Directions)Enum.Parse(typeof(Directions), args[2].Trim()));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Commands/Arguments");
                    }
                    return result;
                case Commands.MOVE:
                    _simulator.Move();
                    return result;
                case Commands.LEFT:
                    _simulator.TurnDirection(Commands.LEFT);
                    return result; 
                case Commands.RIGHT:
                    _simulator.TurnDirection(Commands.RIGHT);
                    return result;
                case Commands.REPORT:
                    _simulator.GetReport();
                    return result;
                default:
                    return result;
            }
        }

        return Commands.UNDEFINED;
    }
}


