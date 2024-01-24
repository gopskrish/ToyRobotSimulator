using ToyRobotSimulator.enums;

namespace ToyRobotSimulator.Interface;

public interface ICommandParser
{
    Commands ParseAndExecute(string commandArgument);
}


