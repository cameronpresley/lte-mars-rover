using System;
using System.IO;
using MarsRover.Services;

namespace MarsRover
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Please enter a full path for logging. Press enter to use a default file.");
      var path = Console.ReadLine();

      ILogger logger = CreateLogger(path);
      var roverDecorator = new RoverDecorator(new Rover(), logger);
      var commandConverter = new UserInputToCommandConverter();
      Command command = Command.Unknown;
      while (command != Command.Quit)
      {
        Console.WriteLine(roverDecorator.FormatRover());
        Console.WriteLine("Enter a valid command:");
        Console.WriteLine("Move (F)orward, Move (B)ackward, Turn (L)eft, Turn (R)ight, (Q)uit");
        var input = Console.ReadLine();
        command = commandConverter.ConvertToCommand(input);
        if (command == Command.Unknown)
        {
          Console.WriteLine("Wasn't able to parse " + input + " as a valid command.");
        }
        else
        {
          roverDecorator.ProcessCommand(command);
        }
      }
    }

    private static ILogger CreateLogger(string path)
    {
      File.Delete(".\\bin\\temp.txt");
      path = String.IsNullOrWhiteSpace(path) ? ".\\bin\\temp.txt" : path;

      ILogger logger;
      try
      {
        logger = new Logger(path);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Failed to create logger, exiting.");
        Console.WriteLine(ex.Message);
        throw;
      }

      return logger;
    }
  }
}
