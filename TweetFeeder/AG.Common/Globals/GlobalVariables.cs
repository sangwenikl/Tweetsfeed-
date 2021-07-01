namespace AG.Common.Globals
{
  /// <summary>
  /// Contains global variables, common across the system.
  /// </summary>
  public static class GlobalVar
  {
    public static string UserFile => "userFile";
    public static string TweetFile => "tweetFile";
    public static string[] NewLineArray => new[] { "\n", "\r\n" };
    public static string US_ASCII => "us-ascii";
    public static char[] CommaCharArray => new[] { ',' };
    public static string Key => "follows";
    public static string CommaDelimiterSeperator => ","; 
  }

  public enum SubstringOptions
  {
    BeforeKey,
    AfterKey
  }

  public enum ValidateOptions
  {
    UsASCII,
    None
  }
}
