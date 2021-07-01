using AG.Common.Abstracts;
using AG.Common.Concretes;
using AG.Common.Extensions;
using AG.Common.Globals;
using AG.Domain.Abstracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace AG.Domain.Concretes
{
  public class TweetFeedGenerator : IFeedGenerator
  {
    private IUserRepository userRepository;

    private ITweetRepository tweetReposity;
    private IInputRetriever inputRetriever;
    private IValidator validator;
    private ILogger logger;

    public TweetFeedGenerator()
    {
      userRepository = new UserRepository();
      tweetReposity = new TweetRepository();
      inputRetriever = new FileDocumentStorage();
      validator = new EncodingValidator();
      logger = new ConsoleLogger();
    }

    public TweetFeedGenerator(IUserRepository userRepository, ITweetRepository tweetReposity, IInputRetriever inputRetriever, IValidator validator, ILogger logger)
    {
      this.userRepository = userRepository;
      this.tweetReposity = tweetReposity;
      this.inputRetriever = inputRetriever;
      this.validator = validator;
      this.logger = logger;
    }

    public void SimulateFeed()
    {
         
      try
      {
        if (inputRetriever == null)
        {
           throw new ArgumentNullException();
        }

        string userFileData = inputRetriever.GetData(UserFilePath);

        if (string.IsNullOrEmpty(userFileData) == true || validator.TryValidate(userFileData, ValidateOptions.UsASCII) == false)
        {
          throw new Exception();
        }

        string tweetfileData = inputRetriever.GetData(TweetFilePath);

        if (string.IsNullOrEmpty(tweetfileData) == true || validator.TryValidate(tweetfileData, ValidateOptions.UsASCII) == false)
        {
          throw new Exception();
        }

        IDictionary<string, string> users = null;
        string[] userlines = userFileData.Split(GlobalVar.NewLineArray, StringSplitOptions.RemoveEmptyEntries);
        foreach (var userline in userlines)
        {
                    users = userRepository.CreateFollowAssociationByLine(userline);
                    
        }

        IDictionary<string, ArrayList> tweets = null;
        string[] tweetLines = tweetfileData.Split(GlobalVar.NewLineArray, StringSplitOptions.RemoveEmptyEntries);
        foreach (var tweetLine in tweetLines)
        {
          tweets = tweetReposity.CreateUserTweetAssociation(tweetLine);
        }

        var usersList = users.GetDictionaryKeyValueToList();
        if (usersList == null)
        {
          throw new ArgumentNullException();
        }
        
        foreach (var userKey in usersList)
        {
          if(logger.TryLog($"{userKey}") == false)
          {
            throw new Exception();
          }

          IList<string> orderedTweetList = new List<string>();

          ArrayList userTweetList;
          if(tweets.TryGetValue(userKey, out userTweetList) == true)
          {
            foreach(var ts in userTweetList)
            {
              orderedTweetList.Add(string.Concat(ts.ToString(), Seperator, userKey));
            }
          }

          string userFollowedKeys;
          if (users.TryGetValue(userKey, out userFollowedKeys) == true)
          {
            foreach(var followedKey in userFollowedKeys.Split(GlobalVar.CommaCharArray))
            {
              ArrayList followedTweetList;
              if (tweets.TryGetValue(followedKey, out followedTweetList) == true)
              {
                foreach(var followedTweet in followedTweetList)
                {
                  orderedTweetList.Add(string.Concat(followedTweet.ToString(), Seperator, followedKey));
                }
              }
            }
          }

          foreach (var orderedTweet in orderedTweetList.OrderBy(x => x))
          {
            string tweetUser = orderedTweet.GetSubstringByKey(Seperator, SubstringOptions.AfterKey);
            string userTWeet = orderedTweet.GetSubstringByKey(Seperator, SubstringOptions.BeforeKey).Substring(1);
            logger.TryLog(CreateTweetFeed(tweetUser, userTWeet)); 
          }
        }
        
      }
      catch(Exception e)
      {
        //Log an exception using the logger class     
        logger.TryLog($"Exception thrown : {e.Message}"); 
      }          
    }

    public string SimulateFeedEx()
    {
        try
        {
            if (inputRetriever == null)
            {
                throw new ArgumentNullException();
            }

            string userFileData = inputRetriever.GetData(UserFilePath);

            if (string.IsNullOrEmpty(userFileData) == true || validator.TryValidate(userFileData, ValidateOptions.UsASCII) == false)
            {
                throw new Exception();
            }

            string tweetfileData = inputRetriever.GetData(TweetFilePath);

            if (string.IsNullOrEmpty(tweetfileData) == true || validator.TryValidate(tweetfileData, ValidateOptions.UsASCII) == false)
            {
                throw new Exception();
            }

            IDictionary<string, string> users = null;
            string[] userlines = userFileData.Split(GlobalVar.NewLineArray, StringSplitOptions.RemoveEmptyEntries);
            foreach (var userline in userlines)
            {
                users = userRepository.CreateFollowAssociationByLine(userline);

            }

            IDictionary<string, ArrayList> tweets = null;
            string[] tweetLines = tweetfileData.Split(GlobalVar.NewLineArray, StringSplitOptions.RemoveEmptyEntries);
            foreach (var tweetLine in tweetLines)
            {
                tweets = tweetReposity.CreateUserTweetAssociation(tweetLine);
            }

            var usersList = users.GetDictionaryKeyValueToList();
            if (usersList == null)
            {
                throw new ArgumentNullException();
            }

            StringBuilder tweetFeedBuilder = new StringBuilder(); 

            foreach (var userKey in usersList)
            {
                if (logger.TryLog($"{userKey}") == false)
                {
                    throw new Exception();
                }

                IList<string> orderedTweetList = new List<string>();

                ArrayList userTweetList;
                if (tweets.TryGetValue(userKey, out userTweetList) == true)
                {
                    foreach (var ts in userTweetList)
                    {
                        orderedTweetList.Add(string.Concat(ts.ToString(), Seperator, userKey));
                    }
                }

                string userFollowedKeys;
                if (users.TryGetValue(userKey, out userFollowedKeys) == true)
                {
                    foreach (var followedKey in userFollowedKeys.Split(GlobalVar.CommaCharArray))
                    {
                        ArrayList followedTweetList;
                        if (tweets.TryGetValue(followedKey, out followedTweetList) == true)
                        {
                            foreach (var followedTweet in followedTweetList)
                            {
                                orderedTweetList.Add(string.Concat(followedTweet.ToString(), Seperator, followedKey));
                            }
                        }
                    }
                }
                
                
                
                foreach (var orderedTweet in orderedTweetList.OrderBy(x => x))
                {
                    string tweetUser = orderedTweet.GetSubstringByKey(Seperator, SubstringOptions.AfterKey);
                    string userTWeet = orderedTweet.GetSubstringByKey(Seperator, SubstringOptions.BeforeKey).Substring(1);

                    tweetFeedBuilder.Append(CreateTweetFeed(tweetUser, userTWeet));
                }
            }

            return tweetFeedBuilder.ToString();
        }
        catch (Exception e)
        {
            //Log an exception using the logger class     
            logger.TryLog($"Exception thrown : {e.Message}");

            return $"Exception thrown : {e.Message}";
        }
    }
        /// <summary>
        /// Builds a tweet feed string.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="tweet"></param>
        /// <returns>Tweet feed if user & tweet provided, otherwise, empty string.</returns>
        public string CreateTweetFeed(string user, string tweet)
    {
      if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(tweet))
      {
        return string.Empty;
      }
        return $"\t@{user}: {tweet}\n";       
    }


        private static string SetUpFolderLevel => @"..\..\..\";
    private static string UserFilePath => Path.Combine(Environment.CurrentDirectory, $"{SetUpFolderLevel}", ConfigurationManager.AppSettings[GlobalVar.UserFile]);
    private static string TweetFilePath => Path.Combine(Environment.CurrentDirectory, $"{SetUpFolderLevel}", ConfigurationManager.AppSettings[GlobalVar.TweetFile]);
    private static string Seperator => "~";
  }
}
