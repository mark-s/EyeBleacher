using System;

namespace EyeBleacher.SubredditUrlProviders
{
    public class Cute : ISubredditUrlProvider
    {
        // List of subreddits that can be used to choose pictures from, feel free to add on to them
        private string[] _cuteSubredditList = {
            "https://www.reddit.com/r/eyebleach/hot.json?sort=hot",
            "https://www.reddit.com/r/aww/hot.json?sort=hot",
            "https://www.reddit.com/r/RarePuppers/hot.json?sort=hot",
            "https://www.reddit.com/r/CatLoaf/hot.json?sort=hot",
            "https://www.reddit.com/r/startledcats/hot.json?sort=hot",
        };


        public string GetRandomSubredditUrl()
        {
            var random = new Random();

            var randInt = random.Next(0, _cuteSubredditList.Length);

            return _cuteSubredditList[randInt];
        }


    }
}
