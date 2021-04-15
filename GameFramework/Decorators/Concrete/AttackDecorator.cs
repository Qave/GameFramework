using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Decorators.Concrete
{
    public class AttackDecorator : CreatureDecorator
    {
        private readonly int _attackValue;
        public ICreature _creature;
        public AttackDecorator(string name, int attackValue, ICreature creature) : base(creature.Name, 0, new Position(creature.Position.PosX, creature.Position.PosY))
        {
            _attackValue = attackValue;
            _creature = creature;
        }


        public override void AddDamage()
        {
            //this.Items = _creature.Items;
            this.Damage += _attackValue;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
