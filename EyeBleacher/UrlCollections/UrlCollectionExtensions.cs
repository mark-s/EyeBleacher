using EyeBleacher.Helpers;

namespace EyeBleacher.UrlCollections
{
    public static class UrlCollectionExtensions
    {
        private static readonly RandomHelper _random;

        static UrlCollectionExtensions()
        {
            _random = new RandomHelper();
        }

        public static string GetRandomUrl(this IUrlCollection urlCollection)
        {
            var urls = urlCollection.Urls;
            var randInt = _random.GetNext(urls.Length);

            return urls[randInt];
        }
    }
}