using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework
{
    public abstract class Creature
    {
        // Global creature class. Should be inherited from Player, and Creatue, perhaps boss/ or strong/elite monsters?

        //Private Fields
        protected int _hitPoints;
        protected bool _isDead;
        protected double _damage;
        protected double _defence;

        public Creature(int hitPoints)
        {
            _damage = 10;
            _defence = 50;
            _isDead = false;
            _hitPoints = hitPoints;
        }

        public int HitPoints { get { return _hitPoints; } set { _hitPoints = value; } }
        public bool IsDead { get { return _isDead; } set { _isDead = value; } }

        public double Damage { get { return _damage; } set { _damage = value; } }
        
        public double Defence { get { return _defence; } set { _defence = value; } }

        // Abstract methods
        public abstract void AddDamage();
    }
}
