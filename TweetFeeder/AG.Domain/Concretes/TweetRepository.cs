using AG.Common.Extensions;
using AG.Common.Globals;
using AG.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AG.Domain.Concretes
{
  public class TweetRepository : ITweetRepository
  {
    private readonly IDictionary<string, ArrayList> userTweetAssocDic;

    private const int MAX_TWEET_LENGTH = 140; // This could be read from the config

    private static string Key => ">"; // This maybe be read from config


    public TweetRepository()
    {
      userTweetAssocDic = new Dictionary<string, ArrayList>(StringComparer.InvariantCultureIgnoreCase);
    }

    public TweetRepository(IDictionary<string, ArrayList> userTweetAssocDic)
    {
      this.userTweetAssocDic = userTweetAssocDic;
    }    

    public IDictionary<string, ArrayList> CreateUserTweetAssociation(string line)
    {
      if (string.IsNullOrEmpty(line) == true)
      {
        return null;
      }

      string user = GetUserByLine(line);

      if (string.IsNullOrEmpty(user) == true)
      {
        return null;
      }

      string tweet = GetTweetByLine(line);

      if (string.IsNullOrEmpty(tweet))
      {
        return null;
      }

      tweet = tweet.GetSubstringByMaxLen(MAX_TWEET_LENGTH);
      ArrayList existingTweets;
      if (userTweetAssocDic.TryGetValue(user, out existingTweets) == true)
      {
        existingTweets.Add($"{++Counter}{tweet}");
        userTweetAssocDic[user] = existingTweets;

        return userTweetAssocDic;
      }

      existingTweets = new ArrayList();
      existingTweets.Add($"{++Counter}{tweet}");
      userTweetAssocDic.Add(user, existingTweets);

      return userTweetAssocDic;
    }

    public string GetTweetByLine(string line)
    {
      if (string.IsNullOrEmpty(line))
      {
        return string.Empty;
      }

      return line.GetSubstringByKey(Key, SubstringOptions.AfterKey).Trim();
    }

    public string GetUserByLine(string line)
    {
      if (string.IsNullOrEmpty(line) == true)
      {
        return string.Empty;
      }

      return line.GetSubstringByKey(Key, SubstringOptions.BeforeKey).Trim();
    }

    private static int Counter = 0;
  }
}
