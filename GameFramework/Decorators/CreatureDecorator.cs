using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Decorators
{
    public abstract class CreatureDecorator : Creature
    {
        protected CreatureDecorator(int hitPoints) : base(hitPoints)
        {
        }
    }
}

