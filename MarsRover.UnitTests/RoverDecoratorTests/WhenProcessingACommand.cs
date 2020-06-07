using MarsRover.Services;
using NSubstitute;
using NUnit.Framework;

namespace MarsRover.UnitTests.RoverDecoratorTests
{
  [TestFixture]
  public class WhenProcessingACommand
  {
    private ILogger _logger;
    private IRover _rover;
    private RoverDecorator _roverDecorator;

    [SetUp]
    public void Setup()
    {
      _rover = Substitute.For<IRover>();
      _logger = Substitute.For<ILogger>();
      _roverDecorator = new RoverDecorator(_rover, _logger);
    }

    [Test]
    public void AndTheCommandIsMoveForwardThenRoverMovedForwardWithLogging()
    {
      _roverDecorator.ProcessCommand(Command.MoveForward);

      _rover.Received(1).MoveForward();
      _logger.Received(1).Log("Rover moved forward.");
      _logger.Received(1).Log(Arg.Is<string>(s => s.StartsWith("Rover is at ")));
    }

    [Test]
    public void AndTheCommandIsMoveBackwardThenRoverMovedBackwardWithLogging()
    {
      _roverDecorator.ProcessCommand(Command.MoveBackward);

      _rover.Received(1).MoveBackward();
      _logger.Received(1).Log("Rover moved backward.");
      _logger.Received(1).Log(Arg.Is<string>(s => s.StartsWith("Rover is at ")));
    }

    [Test]
    public void AndTheCommandIsTurnLeftThenRoverTurnedLeftWithLogging()
    {
      _roverDecorator.ProcessCommand(Command.TurnLeft);

      _rover.Received(1).TurnLeft();
      _logger.Received(1).Log("Rover turned left.");
      _logger.Received(1).Log(Arg.Is<string>(s => s.StartsWith("Rover is at ")));
    }
    [Test]
    public void AndTheCommandIsTurnRightThenRoverTurnedRightWithLogging()
    {
      _roverDecorator.ProcessCommand(Command.TurnRight);

      _rover.Received(1).TurnRight();
      _logger.Received(1).Log("Rover turned right.");
      _logger.Received(1).Log(Arg.Is<string>(s => s.StartsWith("Rover is at ")));
    }
    [Test]
    public void AndTheCommandIsQuitThenTheRoverDoesntMoveWithLogging()
    {
      _roverDecorator.ProcessCommand(Command.Quit);

      _rover.DidNotReceive().MoveForward();
      _rover.DidNotReceive().MoveBackward();
      _rover.DidNotReceive().TurnLeft();
      _rover.DidNotReceive().TurnRight();
      _logger.Received(1).Log("Rover stopped.");
      _logger.Received(1).Log(Arg.Is<string>(s => s.StartsWith("Rover is at ")));
    }
  }
}