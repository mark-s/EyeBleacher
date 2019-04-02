using System;
using System.Linq;
using System.Net;
using EyeBleacher.DTOs;
using Newtonsoft.Json;

namespace EyeBleacher.Subreddits
{
    public class CoolSubredditData
    {
        public string[] GetRandomCoolUrl()
        {
            var client = new WebClient();
            var random = new Random();
            var url = pickRandomCoolSubreddit();
            var coolSubredditJsonDataRAW = client.DownloadString(url);

            var imageLinks = new string[25];
            var imageTitle = new string[100];
            var postAuthor = new string[25];
            var subredditName = new string[25];

            // This uses Newtonsoft.Json to deserialize the downloaded JSON data from reddit
            var usableJsonData = JsonConvert.DeserializeObject<RootObject>(coolSubredditJsonDataRAW);

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

            return new string[] { imageLinks[randInt], imageTitle[randInt], "u/" + postAuthor[randInt], subredditName[randInt] };
        }

        public string pickRandomCoolSubreddit()
        {
            var random = new Random();
            // List of subreddits that can be used to choose pictures from, feel free to add on to them
            string[] coolSubredditList = {
                "https://www.reddit.com/r/astronomy/hot.json?sort=hot",
                "https://www.reddit.com/r/EarthPorn/hot.json?sort=hot",
                "https://www.reddit.com/r/MildlyInteresting/hot.json?sort=hot"
                // Append any further subreddits here
            };

            var randInt = random.Next(0, coolSubredditList.Length);

            return coolSubredditList[randInt];
        }

    }


}
