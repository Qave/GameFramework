using GameFramework.Interfaces;
using GameFramework.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameFramework
{
    public abstract class Creature : ICreature
    {
        //Private Fields
        protected int _hitPoints;
        protected bool _isDead;
        protected double _damage;
        protected double _defence;
        protected Position _position;
        public Creature(int hitPoints, Position position)
        {
            _damage = 10;
            _defence = 50;
            _isDead = false;
            _hitPoints = hitPoints;
            _position = position;        
        }

        public int HitPoints { get { return _hitPoints; } set { _hitPoints = value; } }
        public bool IsDead { get { return _isDead; } set { _isDead = value; } }
        public double Damage { get { return _damage; } set { _damage = value; } }
        public double Defence { get { return _defence; } set { _defence = value; } }

        public Position Position { get { return _position; } set { _position = value; } }



        // Abstract methods
        public abstract void AddDamage();
        public abstract void Draw();




    }
}
