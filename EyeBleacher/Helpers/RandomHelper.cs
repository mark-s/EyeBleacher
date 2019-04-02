using System;

namespace EyeBleacher.Helpers
{
    class RandomHelper : IGetRandom
    {
        private static readonly Random _random = new Random();

        public int GetNext(int max)
        => _random.Next(0, max);
    }

    public interface IGetRandom
    {
        int GetNext(int max);
    }
}
