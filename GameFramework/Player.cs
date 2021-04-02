using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Console;

namespace GameFramework
{
    public class Player : Creature
    {
        // The player object. Should contain things only relevant for the player.

        //Private Fields
        private string _name;
        private readonly string _marker; // Fra XML?
        private readonly ConsoleColor _playerColor; // Fra XML ?
        //Public Properties
        public string Name { get { return _name; } set { _name = value; } }

        /// <summary>
        /// The players position in the gameworld grid; x, y
        /// </summary>
        public Position Position;

        /// <summary>
        /// Instantiates a new Player object
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="hitPoints">Hit Points. 0 = dead</param>
        /// <param name="posX">The Player object's starting X position</param>
        /// <param name="posY">The Player object's starting Y position</param>
        public Player(string name, int hitPoints, Position position) : base(hitPoints)
        {
            Position = position;
            _name = name;
            _marker = "O";
            _playerColor = ConsoleColor.Red;
        }

        // Refactor, World has a draw function too, make draw function in IWorldObject?
        public void Draw()
        {
            ForegroundColor = _playerColor;
            SetCursorPosition(Position.PosX, Position.PosY);
            Write(_marker);
            ResetColor();
        }

        public override void AddDamage()
        {
            this.Damage = this.Damage;
        }
    }
}
