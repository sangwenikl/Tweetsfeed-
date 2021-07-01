using AG.Common.Abstracts;
using System;

namespace AG.Common.Concretes
{
  public class ConsoleLogger : ILogger
  {
    public ConsoleLogger()
    {
    }

    public bool TryLog(string text)
    {
      if (string.IsNullOrEmpty(text) == true)
      {
        return false;
      }
      Console.WriteLine(text);
      return true; 
    }
  }
}
