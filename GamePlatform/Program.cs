using GameFramework;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace GamePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.SetCursorPosition(0,0); No flickering in console window, also you can control placement of objects this way.

            Game game = new Game();
            game.Start();
        }

    }
}
