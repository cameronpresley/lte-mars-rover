using System;

namespace MarsRover.Services
{
  public class UserInputToCommandConverter
  {
    public Command ConvertToCommand(string input)
    {
      switch (input?.ToLower())
      {
        case null: throw new ArgumentNullException(nameof(input));
        case "f": return Command.MoveForward;
        case "b": return Command.MoveBackward;
        case "l": return Command.TurnLeft;
        case "r": return Command.TurnRight;
        case "q": return Command.Quit;
        default: return Command.Unknown;
      }
    }
  }
}