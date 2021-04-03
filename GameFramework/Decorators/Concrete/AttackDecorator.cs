using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Decorators.Concrete
{
    public class AttackDecorator : CreatureDecorator
    {

        ICreature _creature;
        public AttackDecorator(ICreature creature) : base(0)
        {
            _creature = creature;
        }


        public override void AddDamage()
        {
            this.Damage += 10;
        }
    }
}
