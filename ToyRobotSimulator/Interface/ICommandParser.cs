﻿using ToyRobotSimulator.enums;

namespace ToyRobotSimulator.Interface;

public interface ICommandParser
{
    Commands ExecuteCommand(string commandArgument);
}


