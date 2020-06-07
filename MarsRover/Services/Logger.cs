using System;
using System.IO;

namespace MarsRover.Services
{
  public class Logger
  {
    private readonly string _filePath;

    public Logger(string absolutePath)
    {
        if (String.IsNullOrWhiteSpace(absolutePath)) throw new ArgumentException($"{nameof(absolutePath)} cannot be null or empty.");
        if (File.Exists(absolutePath)) throw new ArgumentException($"There's already a file at {absolutePath}");
        var directory = Path.GetDirectoryName(absolutePath);
        if (!Directory.Exists(directory)) throw new ArgumentException($"There's no directory for the file at {directory}");

        try
        {
            File.WriteAllText(absolutePath, "");
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Failed to create a file", ex);
        }
        _filePath = absolutePath;
    }

  public void Log (string message)
  {
    if (String.Equals(message, null)) throw new ArgumentNullException(nameof(message));
    
    File.AppendAllText(_filePath, message+Environment.NewLine);
  }

  }
}