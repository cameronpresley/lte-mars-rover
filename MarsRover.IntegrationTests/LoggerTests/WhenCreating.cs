using System;
using System.IO;
using System.Reflection;
using MarsRover.Services;
using NUnit.Framework;

namespace MarsRover.IntegrationTests.LoggerTests
{
  [TestFixture]
  public class WhenCreating
  {
    [Test]
    public void AndThePathIsNullThenAnExceptionIsThrown()
    {
      Assert.Throws<ArgumentException>(() => new Logger(null));
    }

    [Test]
    public void AndThePathDoesntExistThenAnExceptionIsThrown()
    {
      var notExistentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\doesntExist";
      if (Directory.Exists(notExistentPath))
        Directory.Delete(notExistentPath);

      Assert.Throws<ArgumentException>(() => new Logger(notExistentPath + "\\someFile.txt"));
    }

    [Test]
    public void AndTheFileAlreadyExistsThenAnExceptionIsThrown()
    {
        var absolutePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\someFile.text";
        File.WriteAllText(absolutePath, "some text");

        Assert.Throws<ArgumentException>(() => new Logger(absolutePath));
    }

    [Test]
    public void AndTheFileDoesntExistThenTheLoggerIsCreated()
    {
        var absolutePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\someFile.text";
        File.Delete(absolutePath);

        Assert.DoesNotThrow(() => new Logger(absolutePath));
    }
  }
}