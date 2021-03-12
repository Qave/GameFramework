using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework
{
    public class Monster : Creature
    {
        // Private Fields
        private string _name;
        private CreatureType _creatureType;

        // Public Properties
        public string Name { get { return _name; } set { _name = value; } }

        // Enums
        public enum CreatureType
        {
            Weak,
            Normal,
            Strong,
            Boss
        }

        public Monster(string name, CreatureType creatureType, int hitPoints, int posX, int posY)
            : base(hitPoints, posX, posY)
        {
            _name = name;
            _creatureType = creatureType;
        }
    }
}
