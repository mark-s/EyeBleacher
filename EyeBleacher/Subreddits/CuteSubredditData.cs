using System;
using System.Linq;
using System.Net;
using EyeBleacher.DTOs;
using Newtonsoft.Json;

namespace EyeBleacher.Subreddits
{
    public class CuteSubredditData : IGetSubredditImage
    {
        public SubredditImageInfo GetImageFromSubreddit()
        {
            var client = new WebClient();
            var random = new Random();
            var url = PickRandomCuteSubreddit();
            var cuteSubredditJsonDataRAW = client.DownloadString(url);

            var imageLinks = new string[25];
            var imageTitle = new string[100];
            var postAuthor = new string[25];
            var subredditName = new string[25];

            // This uses Newtonsoft.Json to deserialize the downloaded JSON data from reddit
            var usableJsonData = JsonConvert.DeserializeObject<RootObject>(cuteSubredditJsonDataRAW);

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

        private string PickRandomCuteSubreddit()
        {
            var random = new Random();
            // List of subreddits that can be used to choose pictures from, feel free to add on to them
            string[] cuteSubredditList = {
                "https://www.reddit.com/r/eyebleach/hot.json?sort=hot",
                "https://www.reddit.com/r/aww/hot.json?sort=hot",
                "https://www.reddit.com/r/RarePuppers/hot.json?sort=hot",
                "https://www.reddit.com/r/CatLoaf/hot.json?sort=hot",
                "https://www.reddit.com/r/startledcats/hot.json?sort=hot",

            };

            var randInt = random.Next(0, cuteSubredditList.Length);

            return cuteSubredditList[randInt];
        }


    }
}
