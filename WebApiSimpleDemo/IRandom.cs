using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSimpleDemo
{
    public interface IRandom
    {
        int GetRandom(int min, int max);
    }
}
