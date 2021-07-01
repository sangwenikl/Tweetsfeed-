using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TweetFeeder
{
    public class Program
    {
        static void Main(string[] args)
        {
            string Usersfilepath = @"C:\Users\user1\Documents\Bluetooth Folder\users.txt";
            string Tweetfilepath = @"C:\Users\user1\Documents\Bluetooth Folder\tweets.txt";


            Console.WriteLine(" ");
            List<FollowClass> tweetpost = new List<FollowClass>();
            List<Tweets> k = new List<Tweets>();
            List<string> tweetstry = File.ReadAllLines(Tweetfilepath).ToList();
            List<string> onlyuserlist = File.ReadAllLines(Usersfilepath).ToList();
            Console.WriteLine("users.txt ");
            Console.WriteLine(" ");
            foreach (var use in onlyuserlist)
            {
                string[] user = use.Split(new string[] { "follows" }, StringSplitOptions.RemoveEmptyEntries);

                FollowClass follow = new FollowClass();
                follow.follow = user[0];
                follow.followers = user[1];
                tweetpost.Add(follow);
                Console.WriteLine(use);
            }

            Console.WriteLine(" ");
            Console.WriteLine("Tweets ");
            Console.WriteLine(" ");
            foreach (var me in tweetpost)
            {
                foreach (var item in tweetstry)
                {
                    try
                    {
                        string[] ten = item.Split(',');
                        Tweets khetha = new Tweets();
                        khetha.Username = ten[0];
                        khetha.message = ten[1];

                        Console.WriteLine(khetha.message);
                    }
                    catch(Exception e) {
                        Console.WriteLine(" ");
                    }                   
                }           
                Console.WriteLine($"{me.follow}");
                Console.WriteLine(" ");
                Console.WriteLine($"{ me.followers}");
                Console.WriteLine(" ");
            }
            Console.ReadKey();
        }
    }
}
