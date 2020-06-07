using System;
using System.IO;
using System.Reflection;
using MarsRover.Services;
using NUnit.Framework;

namespace MarsRover.IntegrationTests
{
  [TestFixture]
  public class WhenLogging
  {
    private string _filePath;
    private Logger _logger;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
      _filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\someFile.text";
    }

    [SetUp]
    public void Setup()
    {
      File.Delete(_filePath);
      _logger = new Logger(_filePath);
    }

    [Test]
    public void AndTheMessageIsNullThenAnExceptionIsThrown()
    {
      Assert.Throws<ArgumentNullException>(() => _logger.Log(null));
    }

    [Test]
    public void AndTheMessageIsEmptyThenItsLogged()
    {
      _logger.Log(String.Empty);

      var contents = File.ReadAllText(_filePath);
      var expectedContents = $"{Environment.NewLine}";
      Assert.AreEqual(expectedContents, contents);
    }

    [Test]
    public void AndTheMessageIsSpacesThenItsLogged()
    {
      const string message = "   ";

      _logger.Log(message);

      var contents = File.ReadAllText(_filePath);
      var expectedContents = $"{message}{Environment.NewLine}";
      Assert.AreEqual(expectedContents, contents);
    }

    [Test]
    public void AndTheMessageIsTextThenItsLogged()
    {
      const string message = "I'm a message.";

      _logger.Log(message);

      var contents = File.ReadAllText(_filePath);
      var expectedContents = $"{message}{Environment.NewLine}";
      Assert.AreEqual(expectedContents, contents);
    }

    [Test]
    public void AndLogIsCalledTwiceThenMessagesAreOnSeparateLines()
    {
      const string firstMessage = "First Message.";
      const string secondMessage = "Second Message.";

      _logger.Log(firstMessage);
      _logger.Log(secondMessage);

      var contents = File.ReadAllText(_filePath);
      var expectedContents = $"{firstMessage}{Environment.NewLine}{secondMessage}{Environment.NewLine}";
      Assert.AreEqual(expectedContents, contents);
    }
  }
}