using System;

namespace EyeBleacher.SubredditUrlProviders
{
    public class Wholesome : ISubredditUrlProvider
    {
        public string PickRandomSubreddit()
        {
            var random = new Random();
            // List of subreddits that can be used to choose pictures from, feel free to add on to them
            string[] wholesomeSubredditList = {
                "https://www.reddit.com/r/wholesomememes/hot.json?sort=hot",
                "https://www.reddit.com/r/MadeMeSmile/hot.json?sort=hot",
                "https://www.reddit.com/r/WholesomePics/hot.json?sort=hot",
                "https://www.reddit.com/r/WholesomeComics/hot.json?sort=hot",
                "https://www.reddit.com/r/BeforeNAfterAdoption/hot.json?sort=hot"
                // Append any further subreddits here
            };

            var randInt = random.Next(0, wholesomeSubredditList.Length);

            return wholesomeSubredditList[randInt];
        }
    }
}
