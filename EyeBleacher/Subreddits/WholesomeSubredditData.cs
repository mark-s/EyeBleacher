using System;
using System.Linq;
using System.Net;
using EyeBleacher.DTOs;
using Newtonsoft.Json;

namespace EyeBleacher.Subreddits
{

    class WholesomeSubredditData
    {
        public static string[] getRandomWholesomeURL()
        {
            WebClient client = new WebClient();
            Random random = new Random();
            string url = pickRandomWholesomeSubreddit();
            string wholesomeSubredditJsonDataRAW = client.DownloadString(url);

            string[] imageLinks = new string[25];
            string[] imageTitle = new string[100];
            string[] postAuthor = new string[25];
            string[] subredditName = new string[25];

            // This uses Newtonsoft.Json to deserialize the downloaded JSON data from reddit
            RootObject usableJsonData = JsonConvert.DeserializeObject<RootObject>(wholesomeSubredditJsonDataRAW);

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

        public static string pickRandomWholesomeSubreddit()
        {
            Random random = new Random();
            // List of subreddits that can be used to choose pictures from, feel free to add on to them
            string[] wholesomeSubredditList = {
                "https://www.reddit.com/r/wholesomememes/hot.json?sort=hot",
                "https://www.reddit.com/r/MadeMeSmile/hot.json?sort=hot",
                "https://www.reddit.com/r/WholesomePics/hot.json?sort=hot",
                "https://www.reddit.com/r/WholesomeComics/hot.json?sort=hot",
                "https://www.reddit.com/r/BeforeNAfterAdoption/hot.json?sort=hot"
                // Append any further subreddits here
            };

            int randInt = random.Next(0, wholesomeSubredditList.Length);

            return wholesomeSubredditList[randInt];
        }


    }
}
