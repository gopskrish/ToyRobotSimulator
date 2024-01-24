using Microsoft.Extensions.DependencyInjection;
using ToyRobotSimulator;
using ToyRobotSimulator.enums;
using ToyRobotSimulator.Models;

var serviceProvider = new ServiceCollection()
       .AddSingleton<Robot>()
       .AddSingleton<ISimulator, Simulator>()
       .AddSingleton<ICommandParser, CommandParser>()
       .BuildServiceProvider();

var commandParser = serviceProvider.GetRequiredService<ICommandParser>();

Console.WriteLine("Welcome to Toy robot simulaition");
Console.WriteLine("Please enter the commands");

Commands command;
do
{
    var input = Console.ReadLine().ToUpper().Trim();
    command = commandParser.ParseAndExecute(input);
} while (command != Commands.REPORT);
