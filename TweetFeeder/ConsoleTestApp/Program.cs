using AG.Domain.Abstracts;
using AG.Domain.Concretes;

namespace ConsoleTestApp
{
  class Program
  {
    static void Main(string[] args)
    {
      IFeedGenerator feedGenerator = new TweetFeedGenerator();

      feedGenerator.SimulateFeed();      
    }
  }
}
