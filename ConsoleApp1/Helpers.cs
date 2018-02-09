using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Helpers
    {
        public static Random Random = new Random();

        public static bool FlipCoin()
        {
            if (Random.Next(1) > 0)
                return true;

            else return false;
        }

        public static char GenerateRandomCharacter() => (char) Random.Next(32, 126);

        public static void Wait(int seconds) => Thread.Sleep(seconds * 1000);
    }
}
