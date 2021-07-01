using AG.Common.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AG.Common.Extensions
{
  public static class InputRetriever
  {
    private static readonly IDictionary<Func<string, bool>, IInputRetriever> InputRetrievers = new Dictionary<Func<string, bool>, IInputRetriever>();

    /// <summary>
    /// Registers IInputRetrievers.
    /// </summary>
    /// <param name="evaluator"></param>
    /// <param name="inputRetriever"></param>
    public static void RegisterInputRetriever(Func<string, bool> evaluator, IInputRetriever inputRetriever)
    {
      InputRetrievers.Add(evaluator, inputRetriever);
    }

    /// <summary>
    /// Retrieves an IInputRetriever by filename.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static IInputRetriever ForFileName(string fileName)
    {
      return InputRetrievers.First(x => x.Key(fileName)).Value;
    }
  }
}
