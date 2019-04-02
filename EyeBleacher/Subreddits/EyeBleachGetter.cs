using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EyeBleacher.DTOs;
using EyeBleacher.Helpers;
using EyeBleacher.UrlCollections;
using Newtonsoft.Json;

namespace EyeBleacher.Subreddits
{
    public class EyeBleachGetter : IGetSubredditImage
    {
        private readonly IUrlCollection _urlCollection;
        private readonly IGetRandom _randomSource;

        public EyeBleachGetter(IUrlCollection urlCollection, IGetRandom randomSource)
        {
            _urlCollection = urlCollection;
            _randomSource = randomSource;
        }

        public async Task<SubredditImageInfo> GetImageFromSubredditAsync()
        {
            var client = new WebClient();
            var url = _urlCollection.GetRandomUrl();
            var cuteSubredditJsonDataRAW = await client.DownloadStringTaskAsync(url);

            // This uses Newtonsoft.Json to deserialize the downloaded JSON data from reddit
            var subredditData = JsonConvert.DeserializeObject<SubredditRootDTO>(cuteSubredditJsonDataRAW);

            var subreddits = subredditData.data.children
                                            .Where(i => i.data.url.EndsWith(".jpg"))
                                            .Select(item => new SubredditImageInfo(
                                                item.data.url,
                                                item.data.title,
                                                "u/" + item.data.author,
                                                item.data.subreddit_name_prefixed))
                                            .ToList();

            return subreddits[_randomSource.GetNext(subreddits.Count)];

        }

    }
}
