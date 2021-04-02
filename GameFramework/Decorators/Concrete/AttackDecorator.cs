using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Decorators.Concrete
{
    public class AttackDecorator : CreatureDecorator
    {

        Creature _creature;
        public AttackDecorator(Creature creature) : base(0)
        {
            _creature = creature;
        }



        public override void AddDamage()
        {
            this.Damage += 10;
        }
    }
}
