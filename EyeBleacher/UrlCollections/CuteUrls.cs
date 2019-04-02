using EyeBleacher.Interfaces;

namespace EyeBleacher.UrlCollections
{
    public class CuteUrls : IUrlCollection
    {
        // List of subreddits that can be used to choose pictures from, feel free to add on to them
        public string[] Urls => new[]{
            "https://www.reddit.com/r/eyebleach/hot.json?sort=hot",
            "https://www.reddit.com/r/aww/hot.json?sort=hot",
            "https://www.reddit.com/r/RarePuppers/hot.json?sort=hot",
            "https://www.reddit.com/r/CatLoaf/hot.json?sort=hot",
            "https://www.reddit.com/r/startledcats/hot.json?sort=hot",
        };

    }
}
