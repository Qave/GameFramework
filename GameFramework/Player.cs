using GameFramework.Config;
using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Console;

namespace GameFramework
{
    public class Player : Creature //  > ICreature, > IWorldObject
    {
        //Private Fields
        //private string _name;
        private readonly string _marker;
        private readonly ConsoleColor _playerColor;
        public string Marker { get { return _marker; } }



        public Player(string name, int hitPoints, Position position) : base(name, hitPoints, position)
        {
            _marker = "O";
            _playerColor = ConsoleColor.Yellow;
            Position = position;
        }
        public override void AddDamage()
        {
           
            this.Damage = this.Damage;
        }
        public override void Draw()
        {
            ForegroundColor = _playerColor;
            SetCursorPosition(Position.PosX, Position.PosY);
            Write(_marker);
            ResetColor();
        }
    }
}
