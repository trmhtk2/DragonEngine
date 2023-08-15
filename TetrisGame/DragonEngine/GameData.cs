using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{
    public class GameData {
        public string title = "New Game";
        public Vector2D size = new Vector2D(20, 20);
        public GameData(string title = "", Vector2D size = null) {
            this.title = title;
            this.size = size ?? new Vector2D(61, 30);
        }
    }
}
