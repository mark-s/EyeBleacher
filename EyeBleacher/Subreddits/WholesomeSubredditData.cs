using System.Linq;
using System.Net;
using EyeBleacher.DTOs;
using EyeBleacher.Helpers;
using EyeBleacher.SubredditUrlProviders;
using Newtonsoft.Json;

namespace EyeBleacher.Subreddits
{
    public class WholesomeSubredditData : IGetSubredditImage
    {
        private readonly ISubredditUrlProvider _urlProvider;
        private readonly IGetRandom _randomSource;

        public WholesomeSubredditData(ISubredditUrlProvider urlProvider, IGetRandom randomSource)
        {
            _urlProvider = urlProvider;
            _randomSource = randomSource;
        }

        public SubredditImageInfo GetImageFromSubreddit()
        {
            var client = new WebClient();
            var url = _urlProvider.PickRandomSubreddit();
            var wholesomeSubredditJsonDataRAW = client.DownloadString(url);

            var imageLinks = new string[25];
            var imageTitle = new string[100];
            var postAuthor = new string[25];
            var subredditName = new string[25];

            // This uses Newtonsoft.Json to deserialize the downloaded JSON data from reddit
            var usableJsonData = JsonConvert.DeserializeObject<RootObject>(wholesomeSubredditJsonDataRAW);

            // Go through the data from 
            for (var i = 0; i < 25; i++)
            {
                // Get's rid of any of the links that aren't .jpg files
                if (usableJsonData.data.children[i].data.url.EndsWith(".jpg"))
                {
                    imageTitle[i] = usableJsonData.data.children[i].data.title;
                    postAuthor[i] = usableJsonData.data.children[i].data.author;
                    imageLinks[i] = usableJsonData.data.children[i].data.url;
                    subredditName[i] = usableJsonData.data.children[i].data.subreddit_name_prefixed;

                }
                else
                {
                    imageTitle[i] = null;
                    postAuthor[i] = null;
                    imageLinks[i] = null;
                }
            }

            // Clean arrays of any null elements
            imageLinks = imageLinks.Where(c => c != null).ToArray();
            imageTitle = imageTitle.Where(c => c != null).ToArray();
            postAuthor = postAuthor.Where(c => c != null).ToArray();
            subredditName = subredditName.Where(c => c != null).ToArray();
            var randInt = _randomSource.GetNext(imageLinks.Length);

            return new SubredditImageInfo(imageLinks[randInt], imageTitle[randInt], "u/" + postAuthor[randInt], subredditName[randInt]);
        }




    }
}
