using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Decorators.Concrete
{
    public class AttackDecorator : CreatureDecorator
    {

        public ICreature _creature;
        public AttackDecorator(ICreature creature) : base(0, new Position(creature.Position.PosX, creature.Position.PosY))
        {
            _creature = creature;
        }


        public override void AddDamage()
        {
            this.Damage += 10;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
