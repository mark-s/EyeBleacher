using System.Collections.Generic;

namespace EyeBleacher.Services
{
    public static class ListExtensions
    {
        private static readonly RandomIntService _random;

        static ListExtensions()
        {
            _random = new RandomIntService();
        }

        public static T GetRandomItem<T>(this IList<T> urlCollection)
        {
            var randInt = _random.GetNext(urlCollection.Count - 1);
            return urlCollection[randInt];
        }
    }
}