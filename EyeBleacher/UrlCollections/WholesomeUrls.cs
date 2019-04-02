using EyeBleacher.Interfaces;

namespace EyeBleacher.UrlCollections
{
    public class WholesomeUrls : IUrlCollection
    {
        // List of subreddits that can be used to choose pictures from, feel free to add on to them
        public string[] Urls => new[]{
            "https://www.reddit.com/r/wholesomememes/hot.json?sort=hot",
            "https://www.reddit.com/r/MadeMeSmile/hot.json?sort=hot",
            "https://www.reddit.com/r/WholesomePics/hot.json?sort=hot",
            "https://www.reddit.com/r/WholesomeComics/hot.json?sort=hot",
            "https://www.reddit.com/r/BeforeNAfterAdoption/hot.json?sort=hot"
            // Append any further subreddits here
        };



    }
}
