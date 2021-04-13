using GameFramework;
using GameFramework.Config;
using GameFramework.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace GamePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetCursorPosition(0, 0); No flickering in console window, also you can control placement of objects this way.

            //TraceSource ts = new TraceSource("GameFramework_Tracing");
            //ts.Switch = new SourceSwitch("EventTracing", "All");


            //TraceListener eventLog = new TextWriterTraceListener(new StreamWriter("Events.txt"));
            //ts.Listeners.Add(eventLog);
            //eventLog.Filter = new EventTypeFilter(SourceLevels.All);


            //ts.TraceEvent(TraceEventType.Information, 123, "Does this shit work?");
            //ts.Flush();

            Game game = new Game();
            game.Start();
            //GameConfig conf = ReadGameConfigFile<GameConfig>();
            //Console.WriteLine(conf.PlayerName+  ", "+ conf.PlayerMarker);
            //Console.ReadLine();
        }

    }
}
