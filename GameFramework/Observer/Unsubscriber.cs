using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Observer
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<IWorldObject>> _observers;
        private IObserver<IWorldObject> _observer;

        public Unsubscriber(List<IObserver<IWorldObject>> observers, IObserver<IWorldObject> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
