using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Interfaces
{
    public interface IWorldObject
    {
        public void Draw(IWorldObject _object, Position position, int size = 1);
        public void Destroy(IWorldObject _object);
    }
}
