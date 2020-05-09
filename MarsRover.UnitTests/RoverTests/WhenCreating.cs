using NUnit.Framework;

namespace MarsRover.UnitTests.RoverTests
{
  [TestFixture]
  public class WhenCreating
  {
    [Test]
    public void ThenTheRoverIsAt00()
    {
      var rover = new Rover();

      var expectedLocation = new Coordinate(0, 0);
      Assert.AreEqual(expectedLocation, rover.Location);
    }

    [Test]
    public void ThenTheRoverIsFacingNorth()
    {
      var rover = new Rover();

      Assert.AreEqual(Direction.North, rover.Orientation);
    }
  }
}