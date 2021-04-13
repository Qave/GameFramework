using GameFramework.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Interfaces
{
    public interface IWorldObject
    {
        Position Position { get; set; }
        //public void Draw(IWorldObject _object, Position position, int size = 1);
        //public void Destroy(IWorldObject _object);
        
    }
}
