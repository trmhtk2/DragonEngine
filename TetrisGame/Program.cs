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
        public static ASCII demoGraphic = new ASCII("      █ █       \r\n███   █ █    ████\r\n  █          █   \r\n  ████████████   \r\n");
        public static GameObject demoGameObject = new GameObject(Screen.GetCenterPoint(), 0, 3, null, demoGraphic);

        public static GameData currentGameData;

        public static EventHandler <OnGameDataChangedArgs> onGameDataChanged;
        public static void Main(string[] args)
        {
            onGameDataChanged += SyncGameData;
            SetGameData(new GameData("TETRIS", new Vector2D(100, 63)));
            demoGameObject.OnStart();

            Console.WriteLine(Text.ConvertTextSize("banana is tasty!", Text.TextSize.Large));
            Screen.WaitForKey(false);

            while (true)
            {
                demoGraphic.Rotate(90);
                Console.Clear();
              //  demoGraphic.Rotate(Rotation.RotationAngle._90);
                demoGraphic.DrawGraphic(Screen.GetCenterPoint());
               // demoGameObject.OnUpdate();
                Thread.Sleep(1000);
//                demoGameObject.SetRotation(Rotation.RotationAngle._90);
           // Screen.WaitForKey(true);

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
