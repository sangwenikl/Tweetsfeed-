using AG.Common.Globals;
using System.Collections.Generic;
using System.Linq;

namespace AG.Common.Extensions
{
  public static class EnumerableManipulatorExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dict"></param>
    /// <returns>Flattened dictionary of joined keys & values, ordered ascending</returns>
    public static IList<string> GetDictionaryKeyValueToList(this IDictionary<string, string> dict)
    {
      IList<string> valuesList = new List<string>();

      foreach(var value in dict.Values)
      {

        foreach (var followed in value.Split(GlobalVar.CommaCharArray))
        {
          valuesList.Add(followed.Trim());
        }
      }
      return dict.Keys.Union(valuesList).OrderBy(x => x).ToList();
    }    
  }
}
