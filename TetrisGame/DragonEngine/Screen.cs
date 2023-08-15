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
            int leftPosition = ((Console.WindowWidth) / 2) + offsetLeft;
            int topPosition = ((Console.WindowHeight) / 2) + offsetTop;

            return new Vector2D(leftPosition, topPosition);
        }
        public static void WaitForKey(bool showText = false)
        {
            if (showText)
            {
                Console.WriteLine("Press any key to continue...");
            }
            Console.ReadKey(true);

        }
    }
}
