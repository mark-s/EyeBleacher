using System;

namespace EyeBleacher.SubredditUrlProviders
{
    public class Cute : ISubredditUrlProvider
    {
        public string PickRandomSubreddit()
        {
            var random = new Random();
            // List of subreddits that can be used to choose pictures from, feel free to add on to them
            string[] cuteSubredditList = {
                "https://www.reddit.com/r/eyebleach/hot.json?sort=hot",
                "https://www.reddit.com/r/aww/hot.json?sort=hot",
                "https://www.reddit.com/r/RarePuppers/hot.json?sort=hot",
                "https://www.reddit.com/r/CatLoaf/hot.json?sort=hot",
                "https://www.reddit.com/r/startledcats/hot.json?sort=hot",

            };

            var randInt = random.Next(0, cuteSubredditList.Length);

            return cuteSubredditList[randInt];
        }


    }
}
