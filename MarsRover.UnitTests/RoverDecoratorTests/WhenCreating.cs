using System;
using MarsRover.Services;
using NSubstitute;
using NUnit.Framework;

namespace MarsRover.UnitTests.RoverDecoratorTests
{
    [TestFixture]
    public class WhenCreating
    {
        [Test]
        public void AndRoverIsNullThenAnExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(()=>new RoverDecorator(null, Substitute.For<ILogger>()));
        }
        
        [Test]
        public void AndLoggerIsNullThenAnExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(()=> new RoverDecorator(new Rover(), null));
        }
    }
}