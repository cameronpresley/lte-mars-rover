using NUnit.Framework;

namespace MarsRover.UnitTests.RoverTests
{
  [TestFixture]
  public class WhenTurningLeft
  {
    [Test]
    [TestCase(Direction.North, Direction.West, TestName = "AndFacingNorthThenTheRoverFacesWest")]
    [TestCase(Direction.West, Direction.South, TestName = "AndFacingWestThenTheRoverFacesSouth")]
    [TestCase(Direction.South, Direction.East, TestName = "AndFacingSouthThenTheRoverFacesEast")]
    [TestCase(Direction.East, Direction.North, TestName = "AndFacingEastThenTheRoverFacesNorth")]
    public void RoverTurningLeft(Direction start, Direction expected)
    {
      var rover = new Rover { Orientation = start };
      var initialLocation = rover.Location;

      rover.TurnLeft();

      Assert.AreEqual(expected, rover.Orientation);
      Assert.AreEqual(initialLocation, rover.Location);
    }
  }
}