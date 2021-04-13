using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Observer.Interfaces
{
    public interface IObserver
    {
        void Notify(ICreature creature);
    }
}
