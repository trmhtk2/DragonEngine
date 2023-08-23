using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DragonEngine;

namespace TetrisGame
{
    public class OnGameDataChangedArgs
    {
        public GameData gameData;
        public OnGameDataChangedArgs(GameData gameData)
        {
            this.gameData = gameData;
        }
    }

    public class Program
    {
        public static Text demoText = new Text("Explosion! banana", TextSystem.TextSize.Large);
        public static ASCII demoASCII = new ASCII("░░██████░░\r\n░██░░░░█░░\r\n██░░░░░█░░\r\n██░░░░░█░░\r\n░████░░█░░\r\n░░░░█████░\r\n░░░░░░░░██\r\n");
        public static DragonEngine.Object demoGameObject = new DragonEngine.Object(Screen.GetCenterPoint(), 0, 3, null, demoASCII);

        public static GameData currentGameData;

        public static EventHandler <OnGameDataChangedArgs> onGameDataChanged;



        //רועי המגניב!!!
        public static void Main(string[] args)
        {
            LayerManger.Display();
            //רועי מגניב
            onGameDataChanged += SyncGameData;
            SetGameData(new GameData("TETRIS", new Vector2D(239, 63)));
            demoGameObject.OnStart();

            while (true)
            {
                Thread.Sleep(10);
                demoGameObject.SetPosition(new Vector2D(demoGameObject.GetPosition().x + 1, demoGameObject.GetPosition().y));
                Console.Clear();
                demoGameObject.OnUpdate();
            }
        }

        static void SyncGameData(object sender, OnGameDataChangedArgs e)
        {
            Console.Title = e.gameData.title;
            Console.SetWindowSize(e.gameData.size.x, e.gameData.size.y);
            Console.SetBufferSize(e.gameData.size.x, e.gameData.size.y);
        }

        public static GameData SetGameData(GameData gameData)
        { 
            currentGameData = gameData;
            onGameDataChanged?.Invoke(null, new OnGameDataChangedArgs(gameData));
            return currentGameData;
        }
        static GameData GetGameData() { return currentGameData; }
    }
}
