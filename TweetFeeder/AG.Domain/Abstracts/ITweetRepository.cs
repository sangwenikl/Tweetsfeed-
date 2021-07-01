using System.Collections;
using System.Collections.Generic;

namespace AG.Domain.Abstracts
{
  public interface ITweetRepository
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="line"></param>
    /// <returns>User-followed association as a string based on a given line of text.</returns>
    /// 
    string GetUserByLine(string line);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="line"></param>
    /// <returns>User-tweet association as a string based on a given line of text.</returns>
    /// 
    string GetTweetByLine(string line);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="line"></param>
    /// <returns>User-tweet association as a dictionary based on a given line of text.</returns>
    IDictionary<string, ArrayList> CreateUserTweetAssociation(string line);

  }
}
