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



        public static GameData currentGameData;

        public static EventHandler <OnGameDataChangedArgs> onGameDataChanged;



        //רועי המגניב!!!
        //cbbbv
        public static void Main(string[] args)
        {

            onGameDataChanged += SyncGameData;
            SetGameData(new GameData("TETRIS", new Vector2D(120, 50)));

            LayerManager.OnStart();

            Text demoText = new Text("Explosion! banana", TextSystem.TextSize.Large);
            ASCII demoASCII = new ASCII("░░░░░██░░░░░░░███░\r\n░░░░░█░░░░░░░██░██\r\n░░░░░░░░░░░░██░░██\r\n░░░░░░░░░░░░█░░░░█\r\n░░░░░░░░░░░█░░░███\r\n░░░░░░░░░███████░█\r\n░░░░░░░█████░░░░░█\r\n░░░░░░████░░░░░░░░\r\n░░░░███░░█████░░░█\r\n");
            Entity demoEntity = new Entity(demoASCII);
            demoEntity.OnStart();


            Manger1.Run();
            Manger2.Run();

            while (true)
            {
                Graphic graphic = new Text(Screen.GetCenterPoint().ToString());
                Entity center = new Entity(Screen.GetCenterPoint(), 0, graphic);
                 //   Console.Write(demoEntity.GetPosition());
                demoEntity.SetPosition(Screen.GetCenterPoint());
                LayerManager.OnLoop();
                LayerManager.Display();

                Manger1.Loop();
                Manger2.Loop();

                Thread.Sleep(10);
             //   demoGameObject.SetPosition(new Vector2D(demoGameObject.GetPosition().x + 1, demoGameObject.GetPosition().y));
                demoEntity.OnUpdate();
            }
        }

        static void SyncGameData(object sender, OnGameDataChangedArgs e)
        {
            Console.Title = e.gameData.title;
            Console.SetBufferSize(e.gameData.size.x, e.gameData.size.y);
            Console.SetWindowSize(e.gameData.size.x, e.gameData.size.y);
            Console.CursorVisible = e.gameData.showCursor;
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
