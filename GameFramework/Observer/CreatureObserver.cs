using GameFramework.Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Observer
{
    public class CreatureObserver : IObservable
    {
        private readonly static List<IObserver> _observers = new List<IObserver>();
        public void Add(IObserver observer)
        {
            _observers.Add(observer);
        }
        public static void OnDeath(Creature creature)
        {
            Notify(creature);
        }
        private static void Notify(Creature creature)
        {
            foreach (var observer in _observers)
            {
                observer.Notify(creature);
            }
        }
    }
}
