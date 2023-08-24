using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{
    public static class Screen
    {
        public static Vector2D GetCenterPoint(int offsetLeft = 0, int offsetTop = 0)
        {
            return new Vector2D(Console.WindowWidth / 2 + offsetLeft, Console.WindowHeight / 2 + offsetTop);
        }
        public static void WaitForKey(bool showText = false)
        {
            if (showText)
            {
                Console.WriteLine("Press any key to continue...");
            }
            Console.ReadKey(true);

        }
        public static Vector2D GetSize(bool buffer = false)
        {
            if (buffer)
            {
                return new Vector2D(Console.BufferWidth, Console.BufferHeight);
            }
            return GameData.instance.size;
        }
    }
}
