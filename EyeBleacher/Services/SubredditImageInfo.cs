using System;

namespace EyeBleacher.Services
{
    public class SubredditImageInfo
    {
        public string ImageLink { get; }
        public string PostTitle { get; }
        public string PostAuthor { get; }
        public string SubredditName { get; }

        public SubredditImageInfo(string imageLink, string postTitle, string postAuthor, string subredditName)
        {
            ImageLink = imageLink ?? throw new ArgumentNullException(nameof(imageLink));
            PostTitle = postTitle ?? throw new ArgumentNullException(nameof(postTitle));
            PostAuthor = postAuthor ?? throw new ArgumentNullException(nameof(postAuthor));
            SubredditName = subredditName ?? throw new ArgumentNullException(nameof(subredditName));
        }
    }
}
