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

        public MonsterType _monsterType;
        private readonly string _marker;
        private readonly ConsoleColor _monsterColor;

        // Public Properties
        public MonsterType Monster_Type { get { return _monsterType; } set { _monsterType = value; } }
        public string Marker { get { return _marker; } }

        public Monster(string name, MonsterType monsterType, int hitPoints, Position position) : base(name, hitPoints, position)
        {
            _marker = "M";
            _monsterColor = ConsoleColor.Red;
            Position = position;

            _monsterType = monsterType;
        }
        public override void AddDamage()
        {
            this.Damage = this.Damage;
        }

        public override void Draw()
        {
            ForegroundColor = _monsterColor;
            SetCursorPosition(Position.PosX, Position.PosY);
            Write(_marker);
            ResetColor();
        }
    }
}
