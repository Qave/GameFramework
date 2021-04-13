using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Config
{
    public class GameConfig
    {
        //// World
        //public int WorldSizeX { get; set; }
        //public int WorldSizeY { get; set; }

        // Player
        public string PlayerName { get; set; }
        public string PlayerMarker { get; set; }


        public GameConfig() { }

        public override string ToString()
        {
            return $"Player name: {PlayerName}, Marker: {PlayerMarker}";
        }
    }
}
