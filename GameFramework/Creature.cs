using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework
{
    public abstract class Creature : ICreature
    {
        // Global creatue class. Should be inherited from Player, and Creatue, perhaps boss/ or strong/elite monsters?

        //Private Fields
        protected int _hitPoints;
        protected bool _isDead;
        protected double _damageModifier;
        protected double _defenceModifier;

        public Creature(int hitPoints, double damageModifier, double defenceModifier)
        {
            _damageModifier = damageModifier;
            _defenceModifier = defenceModifier;
            _isDead = false;
            _hitPoints = hitPoints;
        }

        public virtual int HitPoints { get { return _hitPoints; } }
        public virtual bool IsDead { get { return _isDead; } }
        public virtual double DamageModifier { get { return _damageModifier; } }
        public virtual double DefenceModifier { get { return _defenceModifier; } }

    }
}
