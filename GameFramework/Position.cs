using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework
{
    public class Position
    {
        private int _posX;
        private int _posY;

        public int PosX { get; set; }
        public int PosY { get; set; }
        public Position(int posX, int posY)
        {
            _posX = posX;
            _posY = posY;
        }
    }
}
