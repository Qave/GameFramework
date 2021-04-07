using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static GameFramework.Enums.MonsterTypes;
using static System.Console;

namespace GameFramework
{
    public class Monster : Creature
    {
        // Private Fields
        private string _name;
        public MonsterType _monsterType;
        private readonly string _marker; // Fra XML?
        private readonly ConsoleColor _monsterColor; // Fra XML ?
        // Public Properties
        public string Name { get { return _name; } set { _name = value; } }
        public MonsterType Monster_Type { get { return _monsterType; } set { _monsterType = value; } }
        // Enums
        

        public Monster(string name, MonsterType monsterType, int hitPoints, Position position) : base(hitPoints, position)
        {
            _marker = "M";
            Position = position;
            _name = name;
            _monsterType = monsterType;
            _monsterColor = ConsoleColor.Yellow;
        }

        public override void Draw()
        {
            ForegroundColor = _monsterColor;
            SetCursorPosition(Position.PosX, Position.PosY);
            Write(_marker);
            ResetColor();
        }
        public override void AddDamage()
        {
            throw new NotImplementedException();
        }
    }
}
