using AG.Domain.Abstracts;
using System.Collections.Generic;
using System.Linq;
using AG.Common.Extensions;
using System;
using AG.Common.Globals;

namespace AG.Domain.Concretes
{
  public class UserRepository : IUserRepository
  {
    private readonly IDictionary<string, string> follewAssociationDic;

    public UserRepository()
    {
      follewAssociationDic = new SortedDictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }

    public UserRepository(IDictionary<string, string> follewAssociationDic)
    {
      this.follewAssociationDic = follewAssociationDic;
    }

    public string GetFollowerByLine(string line)
    {
      if (string.IsNullOrEmpty(line) == true)
      {
        return string.Empty;
      }

      return line.GetSubstringByKey(GlobalVar.Key, SubstringOptions.BeforeKey).Trim();      
    }

    public string GetFollowedByLine(string line)
    {
      if(string.IsNullOrEmpty(line))
      {
        return string.Empty;
      }

      return line.GetSubstringByKey(GlobalVar.Key, SubstringOptions.AfterKey).Trim();
    }

    public IDictionary<string, string> CreateFollowAssociationByLine(string line)
    {
      if(string.IsNullOrEmpty(line) == true)
      {
        return null;
      }

      string follower = GetFollowerByLine(line);

      if (string.IsNullOrEmpty(follower) == true)
      {
        return null;
      }

      string followed = GetFollowedByLine(line);

      if (string.IsNullOrEmpty(followed))
      {
        return null;
      }

      string existingFollowed;
      if (follewAssociationDic.TryGetValue(follower, out existingFollowed) == true)
      {
        var unionFollowed = existingFollowed.Split(GlobalVar.CommaCharArray).Select(x => x.Trim()).ToArray()
          .Union(followed.Split(GlobalVar.CommaCharArray).Select(y => y.Trim())).ToArray();

        string joinDelimitedFollowed = string.Join(GlobalVar.CommaDelimiterSeperator, unionFollowed);

        follewAssociationDic[follower] = joinDelimitedFollowed;
        return follewAssociationDic;
      }

      follewAssociationDic.Add(follower, followed);

      return follewAssociationDic;
    }
  }
}
