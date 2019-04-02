using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EyeBleacher.DTOs;
using EyeBleacher.Interfaces;
using Newtonsoft.Json;

namespace EyeBleacher.Services
{
    public class EyeBleachService : IGetSubredditImages
    {
        private readonly IUrlCollection _urlCollection;

        public EyeBleachService(IUrlCollection urlCollection)
        {
            _urlCollection = urlCollection;
        }

        public async Task<SubredditImageInfo> GetImageAsync()
        {
            using (var client = new WebClient())
            {
                var url = _urlCollection.Urls.GetRandomItem();

                var json = await client.DownloadStringTaskAsync(url);

                // This uses Newtonsoft.Json to deserialize the downloaded JSON data from reddit
                var subredditData = JsonConvert.DeserializeObject<RedditRootDTO>(json);

                var subreddits = subredditData.data.children
                                            .Where(IsAnImage)
                                            .Select(AsSubredditImageInfo)
                                            .ToList();

                // return a random item
                return subreddits.GetRandomItem();
            }

        }

        private bool IsAnImage(Child item)
            => item.data.url.EndsWith(".png") || item.data.url.EndsWith(".jpg");

        private SubredditImageInfo AsSubredditImageInfo(Child item)
            => new SubredditImageInfo(item.data.url, item.data.title, "u/" + item.data.author, item.data.subreddit_name_prefixed);
    }

}
