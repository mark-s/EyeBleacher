using System;
using EyeBleacher.Interfaces;

namespace EyeBleacher.Services
{
    public class RandomIntService : IGetRandom
    {
        private static readonly Random _random = new Random();

        public int GetNext(int max)
            => _random.Next(0, max);
    }
}
