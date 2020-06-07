using System;
using MarsRover.Services;
using NUnit.Framework;

namespace MarsRover.UnitTests.UserInputToCommandConverterTests
{
  [TestFixture]
  public class WhenConvertingInputToCommands
  {
    [Test]
    public void AndTheInputIsNullThenAnExceptionIsThrown()
    {
      var converter = new UserInputToCommandConverter();

      Assert.Throws<ArgumentNullException>(() => converter.ConvertToCommand(null));
    }

    [Test]
    [TestCase("f", Command.MoveForward, TestName = "AndTheInputIsfThenMoveForwardIsReturned")]
    [TestCase("F", Command.MoveForward, TestName = "AndTheInputIsFThenMoveForwardIsReturned")]
    [TestCase("b", Command.MoveBackward, TestName = "AndTheInputIsbThenMoveBackwardIsReturned")]
    [TestCase("B", Command.MoveBackward, TestName = "AndTheInputIsBThenMoveBackwardIsReturned")]
    [TestCase("l", Command.TurnLeft, TestName = "AndTheInputIslThenTurnLeftIsReturned")]
    [TestCase("L", Command.TurnLeft, TestName = "AndTheInputIsLThenTurnLeftIsReturned")]
    [TestCase("r", Command.TurnRight, TestName = "AndTheInputIsrThenTurnRightIsReturned")]
    [TestCase("R", Command.TurnRight, TestName = "AndTheInputIsRThenTurnRightIsReturned")]
    [TestCase("q", Command.Quit, TestName = "AndTheInputIsqThenQuitIsReturned")]
    [TestCase("Q", Command.Quit, TestName = "AndTheInputIsQThenQuitIsReturned")]
    [TestCase("fake", Command.Unknown, TestName = "AndTheInputIsNotSupportedThenUnknownIsReturned")]
    public void AndTheInputIsFThenMoveForwardIsReturned(string input, Command expectedCommand)
    {
      var converter = new UserInputToCommandConverter();

      var command = converter.ConvertToCommand(input);
      Assert.AreEqual(expectedCommand, command);
    }

  }
}