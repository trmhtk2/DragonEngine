using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{
    public static class Defaults
    {
        public static ConsoleColor Color { get; private set; } = ConsoleColor.White;

        public static ConsoleColor SetColor(ConsoleColor color) { Color = color; return Color; }
    }
}
