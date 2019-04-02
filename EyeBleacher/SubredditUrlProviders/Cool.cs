using System;

namespace EyeBleacher.SubredditUrlProviders
{
    public class Cool : ISubredditUrlProvider
    {
        public string PickRandomSubreddit()
        {
            var random = new Random();
            // List of subreddits that can be used to choose pictures from, feel free to add on to them
            string[] coolSubredditList = {
                "https://www.reddit.com/r/astronomy/hot.json?sort=hot",
                "https://www.reddit.com/r/EarthPorn/hot.json?sort=hot",
                "https://www.reddit.com/r/MildlyInteresting/hot.json?sort=hot"
                // Append any further subreddits here
            };

            var randInt = random.Next(0, coolSubredditList.Length);

            return coolSubredditList[randInt];
        }
    }
}
