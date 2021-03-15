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
        private _Type _creatureType;
        private Position _position;

        // Public Properties
        public string Name { get { return _name; } set { _name = value; } }
        public string Icon { get { return "¤"; } }

        // Enums
        public enum _Type
        {
            Weak = 100,
            Normal = 200,
            Strong = 250,
            Boss = 400
        }

        public Monster(string name, _Type creatureType, int hitPoints, int posX, int posY) : base(hitPoints, posX, posY)
        {
            
            _name = name;
            _creatureType = creatureType;
        }
        public override void Attack() { }
        public override void ReceiveHit() { }
        public override void DropLoot() { }
    }
}
