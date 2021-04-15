using GameFramework.Enums;
using GameFramework.Items.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace GameFramework.Items.ConcreteWeapon
{
    public class ChestArmor : Item, IItem
    {
        protected int _baseDefense;
        private readonly ConsoleColor _chestColor;

        public ChestArmor(int baseDefense, string name, ItemTypes.ItemType itemType, Position position) : base(name, itemType, position)
        {
            _marker = "A";
            _baseDefense = baseDefense;
            _chestColor = ConsoleColor.Green;
        }

        public int BaseDefense { get { return _baseDefense; } set { _baseDefense = value; } }

        public override void Draw()
        {
            ForegroundColor = _chestColor;
            SetCursorPosition(Position.PosX, Position.PosY);
            Write(_marker);
            ResetColor();
        }
    }
}
