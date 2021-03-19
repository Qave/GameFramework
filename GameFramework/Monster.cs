using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static GameFramework.Enums.MonsterTypes;

namespace GameFramework
{
    public class Monster : Creature
    {
        // Private Fields
        private string _name;
        public MonsterType _monsterType;

        // Public Properties
        public string Name { get { return _name; } set { _name = value; } }
        public string Icon { get { return "¤"; } }
        public Position Position { get; set; }
        public MonsterType Monster_Type { get { return _monsterType; } set { _monsterType = value; } }
        // Enums
        

        public Monster(string name, MonsterType monsterType, int hitPoints, Position position) : base(hitPoints)
        {      
            Position = position;
            _name = name;
            _monsterType = monsterType;
        }
        public override void Attack() { }
        public override void ReceiveHit() { }
        public override void DropLoot() { }
    }
}
