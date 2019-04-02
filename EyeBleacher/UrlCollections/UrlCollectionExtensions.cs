using EyeBleacher.Interfaces;
using EyeBleacher.Services;

namespace EyeBleacher.UrlCollections
{
    public static class UrlCollectionExtensions
    {
        private static readonly RandomIntService _random;

        static UrlCollectionExtensions()
        {
            _random = new RandomIntService();
        }

        public static string GetRandomUrl(this IUrlCollection urlCollection)
        {
            var urls = urlCollection.Urls;
            var randInt = _random.GetNext(urls.Length);

            return urls[randInt];
        }
    }
}