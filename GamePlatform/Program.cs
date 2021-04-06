using GameFramework;
using GameFramework.Config;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using static GameFramework.Config.XmlReader;

namespace GamePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.SetCursorPosition(0,0); No flickering in console window, also you can control placement of objects this way.

            //Game game = new Game();
            //game.Start();



            GameConfig conf = ReadGameConfigFile<GameConfig>();
            Console.WriteLine(conf.PlayerName+  ", "+ conf.PlayerMarker);
            Console.ReadLine();
        }

    }
}
