using System;
using System.Linq;
using System.Net;
using EyeBleacher.DTOs;
using Newtonsoft.Json;

namespace EyeBleacher.Subreddits
{
    public class WholesomeSubredditData : IGetSubredditImage
    {
        public SubredditImageInfo GetImageFromSubreddit()
        {
            var client = new WebClient();
            var random = new Random();
            var url = pickRandomWholesomeSubreddit();
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
            var randInt = random.Next(0, imageLinks.Length);

            return new SubredditImageInfo(imageLinks[randInt], imageTitle[randInt], "u/" + postAuthor[randInt], subredditName[randInt]);
        }

        private string pickRandomWholesomeSubreddit()
        {
            var random = new Random();
            // List of subreddits that can be used to choose pictures from, feel free to add on to them
            string[] wholesomeSubredditList = {
                "https://www.reddit.com/r/wholesomememes/hot.json?sort=hot",
                "https://www.reddit.com/r/MadeMeSmile/hot.json?sort=hot",
                "https://www.reddit.com/r/WholesomePics/hot.json?sort=hot",
                "https://www.reddit.com/r/WholesomeComics/hot.json?sort=hot",
                "https://www.reddit.com/r/BeforeNAfterAdoption/hot.json?sort=hot"
                // Append any further subreddits here
            };

            var randInt = random.Next(0, wholesomeSubredditList.Length);

            return wholesomeSubredditList[randInt];
        }


    }
}
