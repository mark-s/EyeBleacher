using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EyeBleacher.DTOs;
using EyeBleacher.Interfaces;
using EyeBleacher.UrlCollections;
using Newtonsoft.Json;

namespace EyeBleacher.Services
{
    public class EyeBleachGetter : IGetSubredditImages
    {
        private readonly IUrlCollection _urlCollection;
        private readonly IGetRandom _randomSource;

        public EyeBleachGetter(IUrlCollection urlCollection)
        {
            _urlCollection = urlCollection;
            _randomSource = new RandomIntService();
        }

        public async Task<SubredditImageInfo> GetImageAsync()
        {
            using (var client = new WebClient())
            {
                var url = _urlCollection.GetRandomUrl();
                var redditData = await client.DownloadStringTaskAsync(url);

                // This uses Newtonsoft.Json to deserialize the downloaded JSON data from reddit
                var subredditData = JsonConvert.DeserializeObject<RedditRootDTO>(redditData);

                var subreddits = subredditData.data.children
                    .Where(i => i.data.url.EndsWith(".png") || i.data.url.EndsWith(".jpg"))
                    .Select(item => new SubredditImageInfo(
                        item.data.url,
                        item.data.title,
                        "u/" + item.data.author,
                        item.data.subreddit_name_prefixed))
                    .ToList();

                // return a random item
                return subreddits[_randomSource.GetNext(subreddits.Count-1)];
            }
                

        }

    }



}
