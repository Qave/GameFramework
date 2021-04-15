using GameFramework.Items.ConcreteArmor;
using GameFramework.Items.ConcreteWeapon;
using GameFramework.Items.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static GameFramework.Enums.ItemTypes;
using static System.Console;

namespace GameFramework.Items
{
    public abstract class Item : IItem
    {
        protected string _name;
        protected ItemType _itemType;
        protected Position _position;
        protected string _marker;
        

        public Item(string name, ItemType itemType, Position position)
        {
            _name = name;
            _itemType = itemType;
            _position = position;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public ItemType ItemType { get { return _itemType; } set { _itemType = value; } }
        public Position Position { get { return _position; } set { _position = value; } }
        public string Marker { get { return _marker; } }

        public void Draw(ConsoleColor color, string marker)
        {
            ForegroundColor = color;
            SetCursorPosition(this.Position.PosX, this.Position.PosY);
            Write(marker);
            ResetColor();
        }

        public abstract void Draw();
    }
}
