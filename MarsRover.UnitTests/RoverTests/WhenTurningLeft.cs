using NUnit.Framework;

namespace MarsRover.UnitTests.RoverTests
{
    [TestFixture]
    public class WhenTurningLeft
    {
        [Test]
        public void AndFacingNorthThenRoverFacesWest()
        {
            var rover = new Rover{Orientation=Direction.North};
            var initialLocation = rover.Location;

            rover.TurnLeft();

            Assert.AreEqual(Direction.West, rover.Orientation);
            Assert.AreEqual(initialLocation, rover.Location);
        }
    }
}