using NUnit.Framework;

namespace MarsRover.UnitTests.RoverTests
{
  [TestFixture]
  public class WhenMovingForward
  {
    [Test]
    public void AndFacingNorthThenYIncreasesByOne()
    {
      var rover = new Rover { Orientation = Direction.North };
      var initialLocation = rover.Location;

      rover.MoveForward();

      var expectedLocation = new Coordinate(initialLocation.X, initialLocation.Y + 1);
      Assert.AreEqual(expectedLocation, rover.Location);
      Assert.AreEqual(Direction.North, rover.Orientation);
    }

    [Test]
    public void AndFacingEastThenXIncreasesByOne()
    {
      var rover = new Rover { Orientation = Direction.East };
      var initialLocation = rover.Location;

      rover.MoveForward();

      var expectedLocation = new Coordinate(initialLocation.X + 1, initialLocation.Y);
      Assert.AreEqual(expectedLocation, rover.Location);
      Assert.AreEqual(Direction.East, rover.Orientation);
    }

    [Test]
    public void AndFacingSouthThenYDecreasesByOne()
    {
      var rover = new Rover { Orientation = Direction.South };
      var initialLocation = rover.Location;

      rover.MoveForward();

      var expectedLocation = new Coordinate(initialLocation.X, initialLocation.Y - 1);
      Assert.AreEqual(expectedLocation, rover.Location);
      Assert.AreEqual(Direction.South, rover.Orientation);
    }

    [Test]
    public void AndFacingWestThenXDecreasesByOne()
    {
      var rover = new Rover { Orientation = Direction.West };
      var initialLocation = rover.Location;

      rover.MoveForward();

      var expectedLocation = new Coordinate(initialLocation.X - 1, initialLocation.Y);
      Assert.AreEqual(expectedLocation, rover.Location);
      Assert.AreEqual(Direction.West, rover.Orientation);
    }
  }
}