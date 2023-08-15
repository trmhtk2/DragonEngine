using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{

    public class Vector2D
    {
        public int x;
        public int y;
        public Vector2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Returns a Vector2D with 0 as the value of X and Y
        /// </summary>
        public static Vector2D Zero = new Vector2D(0, 0);

        /// <summary>
        /// Returns a Vector2D with 1 as the value of X and Y
        /// </summary>
        public static Vector2D One = new Vector2D(1, 1);
    }
}
