using NUnit.Framework;

namespace MarsRover.UnitTests.RoverTests
{
  [TestFixture]
  public class WhenTurningRight
  {
    [Test]
    [TestCase(Direction.North, Direction.East, TestName = "AndFacingNorthThenTheRoverFacesEast")]
    [TestCase(Direction.East, Direction.South, TestName = "AndFacingEastThenTheRoverFacesSouth")]
    [TestCase(Direction.South, Direction.West, TestName = "AndFacingSouthThenTheRoverFacesWest")]
    [TestCase(Direction.West, Direction.North, TestName = "AndFacingWestThenTheRoverFacesNorth")]
    public void RoverTurningRight(Direction start, Direction expected)
    {
      var rover = new Rover { Orientation = start };
      var initialLocation = rover.Location;

      rover.TurnRight();

      Assert.AreEqual(expected, rover.Orientation);
      Assert.AreEqual(initialLocation, rover.Location);
    }
  }
}