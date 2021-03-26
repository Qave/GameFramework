using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Decorators
{
    public abstract class CreatureDecorator : ICreature, IItem
    {
        public string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

// ICreature attackDec = new AttackDecorator(item, monster);