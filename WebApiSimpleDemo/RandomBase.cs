using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSimpleDemo
{
    public class RandomBase : IRandom
    {
        private static Random _random = new Random();

        public int GetRandom(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
