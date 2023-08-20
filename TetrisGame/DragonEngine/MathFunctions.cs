using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{
    public static class MathFunctions
    {
        private static Random random = new Random();

        /// <summary>
        /// Returns a Random int between given min and max values. The method returns values up to,including the maxValue
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandom(int min = 0, int max = 1)
        {
            return random.Next(min, max + 1);
        }

        public static int GetRandomDigitSequence(int amount = 6, int min = 0, int max = 9)
        {
            int sequence = 0;
            for (int i = 0; i < amount; i++) 
            {
                int digit = random.Next(min, max);
                sequence = sequence * 10 + digit;
            }
            return sequence;
        }
    }
}
