
namespace AG.Common.Abstracts
{
  public interface IInputRetriever
  {
    /// <summary>
    /// Retrieves the data from the name if specified
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>
    /// String format for the content of the file
    /// </returns>
    string GetData(string fileName);

  }
}
