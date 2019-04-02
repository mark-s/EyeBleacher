﻿using System.Linq;
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

        public EyeBleachGetter(IUrlCollection urlCollection)
        {
            _urlCollection = urlCollection;
            _randomSource = new RandomHelper();
        }

        public async Task<SubredditImageInfo> GetImageFromSubredditAsync()
        {
            using (var client = new WebClient())
            {
                var url = _urlCollection.GetRandomUrl();
                var redditData = await client.DownloadStringTaskAsync(url);

                // This uses Newtonsoft.Json to deserialize the downloaded JSON data from reddit
                var subredditData = JsonConvert.DeserializeObject<SubredditRootDTO>(redditData);

                var subreddits = subredditData.data.children
                    .Where(i => i.data.url.EndsWith(".jpg"))
                    .Select(item => new SubredditImageInfo(
                        item.data.url,
                        item.data.title,
                        "u/" + item.data.author,
                        item.data.subreddit_name_prefixed))
                    .ToList();

                // return a random item
                return subreddits[_randomSource.GetNext(subreddits.Count)];
            }
                

        }

    }



}
