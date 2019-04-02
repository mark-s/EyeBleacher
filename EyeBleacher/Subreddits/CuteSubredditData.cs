using System.Collections.Generic;
using System.Linq;
using System.Net;
using EyeBleacher.DTOs;
using EyeBleacher.Helpers;
using EyeBleacher.SubredditUrlProviders;
using Newtonsoft.Json;

namespace EyeBleacher.Subreddits
{
    public class CuteSubredditData : IGetSubredditImage
    {
        private readonly ISubredditUrlProvider _urlProvider;
        private readonly IGetRandom _randomSource;

        public CuteSubredditData(ISubredditUrlProvider urlProvider, IGetRandom randomSource)
        {
            _urlProvider = urlProvider;
            _randomSource = randomSource;
        }

        public SubredditImageInfo GetImageFromSubreddit()
        {
            var client = new WebClient();
            var url = _urlProvider.PickRandomSubreddit();
            var cuteSubredditJsonDataRAW = client.DownloadString(url);

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
