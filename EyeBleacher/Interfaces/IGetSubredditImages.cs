using System.Threading.Tasks;
using EyeBleacher.Services;

namespace EyeBleacher.Interfaces
{
    internal interface IGetSubredditImages
    {
        Task<SubredditImageInfo> GetImageAsync();
    }
}