using EyeBleacher.Interfaces;

namespace EyeBleacher.UrlCollections
{
    public class CoolUrls : IUrlCollection
    {
        // List of subreddits that can be used to choose pictures from, feel free to add on to them
        public string[] Urls => new[]{
            "https://www.reddit.com/r/astronomy/hot.json?sort=hot",
            "https://www.reddit.com/r/EarthPorn/hot.json?sort=hot",
            "https://www.reddit.com/r/MildlyInteresting/hot.json?sort=hot"
            // Append any further subreddits here
        };

    }
}
