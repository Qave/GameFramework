using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Observer.Interfaces
{
    public interface IObservable
    {
        void Add(IObserver observer);
    }
}
