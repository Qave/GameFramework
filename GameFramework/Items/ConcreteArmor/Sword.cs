using GameFramework.Enums;
using GameFramework.Items.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static GameFramework.Enums.ItemTypes;
using static System.Console;

namespace GameFramework.Items.ConcreteArmor
{
    public class Sword : Item, IItem
    {

        private int _attackPower;
        private readonly ConsoleColor _swordColor;

        public Sword(int attackPower, string name, ItemType itemType, Position position) : base(name, itemType, position)
        {
            _marker = "W";
            _attackPower = attackPower;
            _swordColor = ConsoleColor.Green;
        }

        public int AttackPower { get { return _attackPower; } set { _attackPower = value; } }

        public override void Draw()
        {
            ForegroundColor = _swordColor;
            SetCursorPosition(Position.PosX, Position.PosY);
            Write(_marker);
            ResetColor();
        }
    }
}
