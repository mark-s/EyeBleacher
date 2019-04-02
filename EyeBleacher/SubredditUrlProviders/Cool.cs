using System;

namespace EyeBleacher.SubredditUrlProviders
{
    public class Cool : ISubredditUrlProvider
    {
        // List of subreddits that can be used to choose pictures from, feel free to add on to them
        private string[] _coolSubreddits = {
            "https://www.reddit.com/r/astronomy/hot.json?sort=hot",
            "https://www.reddit.com/r/EarthPorn/hot.json?sort=hot",
            "https://www.reddit.com/r/MildlyInteresting/hot.json?sort=hot"
            // Append any further subreddits here
        };


        public string GetRandomSubredditUrl()
        {
            var random = new Random();
            var randInt = random.Next(0, _coolSubreddits.Length);

            return _coolSubreddits[randInt];
        }
    }
}
