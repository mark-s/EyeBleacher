using System.Threading.Tasks;

namespace EyeBleacher.Subreddits
{
    interface IGetSubredditImage
    {
        Task<SubredditImageInfo> GetImageFromSubredditAsync();
    }
}