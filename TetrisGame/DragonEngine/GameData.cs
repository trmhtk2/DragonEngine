using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonEngine
{
    public class GameData {
        public static GameData instance;
        public string title = "New Game";
        public Vector2D size = new Vector2D(20, 20);
        public bool showCursor = false;
        public GameData(string title, Vector2D size, bool showCursor = false)
        {
            instance = this;
            this.title = title;
            this.showCursor = showCursor;
        }
    } 
}
