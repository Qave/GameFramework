using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Interfaces
{
    public interface ILootable
    {
        public void OnLooting(IWorldObject worldObject);

    }
}
