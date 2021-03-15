using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Interfaces
{
    public interface IWorldObject
    {
        public void PlaceObjectInWorld(IWorldObject _object, Position position, int size = 1);
        void DestroyObject(IWorldObject _object);
    }
}
