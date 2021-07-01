namespace AG.Common.Abstracts
{
  public interface ILogger
  {
    /// <summary>
    /// Tries to log the given line of text.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>True if the line of text was logged successfully, otherise False.</returns>
    bool TryLog(string text);
  }
}
