using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{

    public struct Vector2D
    {
        public int x;
        public int y;
        public Vector2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Vector2D a, Vector2D b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Vector2D a, Vector2D b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2D other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }



        private static readonly Vector2D zeroVector = new Vector2D(0, 0);

        private static readonly Vector2D oneVector = new Vector2D(1, 1);

        /// <summary>
        /// Returns a Vector2D with 0 as the value of X and Y
        /// </summary>
        public static Vector2D zero
        {
            get
            {
                return zeroVector;
            }
        }

        /// <summary>
        /// Returns a Vector2D with 1 as the value of X and Y
        /// </summary>
        public static Vector2D one
        {
            get
            {
                return oneVector;
            }
        }

        public override string ToString()
        {
            return $"({x}:{y})";
        }
    }

}
