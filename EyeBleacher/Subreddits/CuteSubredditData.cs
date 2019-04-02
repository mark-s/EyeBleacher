using System;
using System.Linq;
using System.Net;
using EyeBleacher.DTOs;
using Newtonsoft.Json;

namespace EyeBleacher.Subreddits
{

    class CuteSubredditData
    {
        public static string[] getRandomEyebleachURL()
        {
            WebClient client = new WebClient();
            Random random = new Random();
            string url = pickRandomCuteSubreddit();
            string cuteSubredditJsonDataRAW = client.DownloadString(url);

            string[] imageLinks = new string[25];
            string[] imageTitle = new string[100];
            string[] postAuthor = new string[25];
            string[] subredditName = new string[25];

            // This uses Newtonsoft.Json to deserialize the downloaded JSON data from reddit
            RootObject usableJsonData = JsonConvert.DeserializeObject<RootObject>(cuteSubredditJsonDataRAW);

            // Go through the data from 
            for (int i = 0; i < 25; i++)
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
            int randInt = random.Next(0, imageLinks.Length);

            return new string[] { imageLinks[randInt], imageTitle[randInt], "u/" + postAuthor[randInt], subredditName[randInt] };
        }

        public static string pickRandomCuteSubreddit()
        {
            Random random = new Random();
            // List of subreddits that can be used to choose pictures from, feel free to add on to them
            string[] cuteSubredditList = {
                "https://www.reddit.com/r/eyebleach/hot.json?sort=hot",
                "https://www.reddit.com/r/aww/hot.json?sort=hot",
                "https://www.reddit.com/r/RarePuppers/hot.json?sort=hot",
                "https://www.reddit.com/r/CatLoaf/hot.json?sort=hot",
                "https://www.reddit.com/r/startledcats/hot.json?sort=hot",

            };

            int randInt = random.Next(0, cuteSubredditList.Length);

            return cuteSubredditList[randInt];
        }


    }
}
