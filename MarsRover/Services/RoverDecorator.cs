using System;

namespace MarsRover.Services
{
  public class RoverDecorator
  {
    private readonly IRover _rover;
    private readonly ILogger _logger;

    public RoverDecorator(IRover rover, ILogger logger)
    {
      _rover = rover ?? throw new ArgumentNullException(nameof(rover));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void ProcessCommand(Command command)
    {
      switch (command)
      {
        case Command.MoveForward:
          _rover.MoveForward();
          _logger.Log("Rover moved forward.");
          _logger.Log(FormatRover(_rover));
          break;
        case Command.MoveBackward:
          _rover.MoveBackward();
          _logger.Log("Rover moved backward.");
          _logger.Log(FormatRover(_rover));
          break;
        case Command.TurnLeft:
          _rover.TurnLeft();
          _logger.Log("Rover turned left.");
          _logger.Log(FormatRover(_rover));
          break;
        case Command.TurnRight:
          _rover.TurnRight();
          _logger.Log("Rover turned right.");
          _logger.Log(FormatRover(_rover));
          break;
        case Command.Quit:
          _logger.Log("Rover stopped");
          _logger.Log(FormatRover(_rover));
          break;
      }
    }

    private string FormatRover(IRover rover)
    {
      return $"Rover is at ({rover.Location.X}, {rover.Location.Y}) facing {rover.Orientation}";
    }
  }
}