using AG.Common.Globals;
using System;
using System.Linq;

namespace AG.Common.Extensions
{
  public static class StringManipulatorExtensions
  {
    /// <summary>
    ///  
    /// </summary>
    /// <param name="str"></param>
    /// <param name="delimiters"></param>
    /// <returns></returns>
    public static string GetFirstWord(this string str, char [] delimiters)
    {
      return string.IsNullOrEmpty(str) == true ? string.Empty : str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).First().Trim();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <param name="key"></param>
    /// <param name="option"></param>
    /// <returns>Original string if it does not contain the key, otherwise a substring depending on the option specified.</returns>
    public static string GetSubstringByKey(this string str, string key, SubstringOptions option)
    {
      if (string.IsNullOrEmpty(str) == true || string.IsNullOrEmpty(key) == true || str.Contains(key) == false)
      {
        return str;
      }

      str = str.Trim();
      key = key.Trim();
      int keyIndex = str.IndexOf(key);

      switch (option)
      {
        case SubstringOptions.BeforeKey:
          return str.Substring(0, keyIndex);
        case SubstringOptions.AfterKey:            
         return str.Substring(keyIndex + key.Length);          
        default:
          //Log this???
          return str;
      }      
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <param name="maxLength"></param>
    /// <returns>A string value, other a substring of the length provided.</returns>
    public static string GetSubstringByMaxLen(this string str, int maxLength)
    {
      if (string.IsNullOrEmpty(str) == true)
      {
        return str;
      }

      return str.Length <= maxLength ? str : str.Substring(0, maxLength);
    }
  }
}
