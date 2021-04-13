using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework
{
    public class Position
    {
        private int _posX;
        private int _posY;

        public int PosX { get { return _posX; } set { _posX = value; } }
        public int PosY { get { return _posY; } set { _posY = value; } }
        public Position(int posX, int posY)
        {
            _posX = posX;
            _posY = posY;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return PosX == (obj as Position).PosX && PosY == (obj as Position).PosY;
        }
    }
}
