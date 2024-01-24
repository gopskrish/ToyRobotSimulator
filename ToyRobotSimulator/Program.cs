using Microsoft.Extensions.DependencyInjection;
using ToyRobotSimulator;
using ToyRobotSimulator.enums;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.Models;

var serviceProvider = new ServiceCollection()
       .AddScoped<Robot>()
       .AddScoped<ISimulator, Simulator>()
       .AddScoped<ICommandParser, CommandParser>()
       .BuildServiceProvider();

var commandParser = serviceProvider.GetRequiredService<ICommandParser>();

Console.WriteLine("Welcome to Toy robot simulaition");
Console.WriteLine("The following commands are used to play this simulators");
Console.WriteLine(@"1. PLACE X,Y,F (Where X and Y are numbers between 0-4 and F is facing Direction i.e North, East, South and West)
2. MOVE
3. LEFT
4. RIGHT
5. REPORT");

Console.WriteLine("Please enter your commands");

Commands command;
do
{
    var input = Console.ReadLine().ToUpper().Trim();
    command = commandParser.ParseAndExecute(input);
} while (command != Commands.REPORT);
