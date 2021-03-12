using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework
{
    public class World
    {
        // Private Fields
        private int _sizeX;
        private int _sizeY;
        private int _worldLevel;

        //Public Properties
        public int SizeX { get => _sizeX; set { _sizeX = value; } }
        public int SizeY { get => _sizeY; set { _sizeY = value; } }
        public int WorldLevel { get => _worldLevel; set { _worldLevel = value; } }


        /// <summary>
        /// World Creation
        /// </summary>
        /// <param name="sizeX">The width of your world</param>
        /// <param name="sizeY">The height of your world</param>
        /// <param name="worldLevel">The world level. To be implemented</param>
        public World(int sizeX, int sizeY, int worldLevel)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _worldLevel = worldLevel;
        }
    }
}
