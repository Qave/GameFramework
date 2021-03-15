using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework
{
    public abstract class Creature : IWorldObject
    {
        // Global creatue class. Should be inherited from Player, and Creatue, perhaps boss/ or strong/elite monsters?

        //Private Fields
        private int _hitPoints;
        private bool _isDead;
        private double _damageModifier;
        private double _defenceModifier;

        //Public Properties
        /// <summary>
        /// The Creatures Hit Points. If this reaches zero, IsDead should be set to true
        /// </summary>
        public int HitPoints { get { return _hitPoints; } set { _hitPoints = value; } }

        /// <summary>
        /// Bool to determine the state of the creatue. Alive/Dead. Creature object gets destroyed on true.
        /// </summary>
        public bool IsDead { get { return _isDead; } set { _isDead = value; } }
        /// <summary>
        /// Damage Modifier. This will increase the creatures damage output per hit. by x.x%
        /// </summary>
        public double DamageModifier { get { return _damageModifier; } set { _damageModifier = value; } }

        /// <summary>
        /// Defence Modifier. This will decrease the creatures recieved damage by x.x% 
        /// </summary>
        public double DefenceModifier { get { return _defenceModifier; } set { _defenceModifier = value; } }


        public Creature(int hitPoints)
        {
            _damageModifier = 0;
            _defenceModifier = 0;
            _isDead = false;
            _hitPoints = hitPoints;
        }


        public abstract void Attack();
        public abstract void ReceiveHit();
        public abstract void DropLoot();

        public void Draw(IWorldObject _object, Position position, int size = 1)
        {
            throw new NotImplementedException();
        }
        public void Destroy(IWorldObject _object)
        {
            throw new NotImplementedException();
        }
    }
}
