using AG.Common.Abstracts;
using System.IO;

namespace AG.Common.Concretes
{
  public class FileDocumentStorage : IInputRetriever
  {
    private ILogger logger;

    public FileDocumentStorage()
    {
      logger = new ConsoleLogger();
    }

    public FileDocumentStorage(ILogger logger)
    {
      this.logger = logger;
    }

    public string GetData(string fileName)
    {
      if (File.Exists(fileName) == false)
      {
        // Log this, say, using log4net
        logger.TryLog("Could not find a file with that name...");
        return string.Empty;
      }        

      using (var stream = File.OpenRead(fileName))
      {
        using (var reader = new StreamReader(stream))
        {
          return reader.ReadToEnd();
        }
      }
    }
  }
}
