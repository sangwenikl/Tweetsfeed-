using System.Collections.Generic;

namespace AG.Domain.Abstracts
{ 
  public interface IUserRepository
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="line"></param>
    /// <returns>A follower user as a string based on a given line of text.</returns>
    string GetFollowerByLine(string line);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="line"></param>
    /// <returns>Followed user(s) as a string based on a given line of text.</returns>
    /// 
    string GetFollowedByLine(string line);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="line"></param>
    /// <returns>User-Followed association as a dictionary based on a given line of text.</returns>
    IDictionary<string, string> CreateFollowAssociationByLine(string line);
  }
}
