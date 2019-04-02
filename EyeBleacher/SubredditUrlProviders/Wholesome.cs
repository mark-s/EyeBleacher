using System;

namespace EyeBleacher.SubredditUrlProviders
{
    public class Wholesome : ISubredditUrlProvider
    {
        // List of subreddits that can be used to choose pictures from, feel free to add on to them
        private string[] _wholesomeSubreddits = {
            "https://www.reddit.com/r/wholesomememes/hot.json?sort=hot",
            "https://www.reddit.com/r/MadeMeSmile/hot.json?sort=hot",
            "https://www.reddit.com/r/WholesomePics/hot.json?sort=hot",
            "https://www.reddit.com/r/WholesomeComics/hot.json?sort=hot",
            "https://www.reddit.com/r/BeforeNAfterAdoption/hot.json?sort=hot"
            // Append any further subreddits here
        };


        public string GetRandomSubredditUrl()
        {
            var random = new Random();

            var randInt = random.Next(0, _wholesomeSubreddits.Length);

            return _wholesomeSubreddits[randInt];
        }
    }
}
