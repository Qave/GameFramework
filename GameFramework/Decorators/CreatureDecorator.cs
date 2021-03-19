using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Decorators
{
    public abstract class CreatureDecorator : Creature,IItem
    {
        private readonly IItem _item;
        public CreatureDecorator(IItem item, int hitPoints) : base(hitPoints)
        {
            _item = item;
        }
    }
}
