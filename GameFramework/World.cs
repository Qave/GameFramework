﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework
{
    public class World
    {

        // On world creation, initialize a random amount of monsters, lootables, maybe walls?? and an exit ?? / unlock after killing boss?
        // Handle staging inside this class, statically, more mobs per stage?

        // Private Fields
        private int _sizeX;
        private int _sizeY;
        private static int _stage = 0;

        //Public Properties
        public int SizeX { get => _sizeX; set { _sizeX = value; } }
        public int SizeY { get => _sizeY; set { _sizeY = value; } }


        /// <summary>
        /// World Creation
        /// </summary>
        /// <param name="sizeX">The width of your world</param>
        /// <param name="sizeY">The height of your world</param>
        /// <param name="worldLevel">The world level. To be implemented</param>
        public World(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;

        }
    }
}
