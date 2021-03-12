using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameFramework
{
    public class Player : Creature
    {
        // The player object. Should contain things only relevant for the player.

        //Private Fields
        private readonly string _name;

        //Public Properties
        public string Name { get; set; }


        /// <summary>
        /// Instantiates a new Player object
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="hitPoints">Hit Points. 0 = dead</param>
        /// <param name="posX">The Player object's starting X position</param>
        /// <param name="posY">The Player object's starting Y position</param>
        public Player(string name, int hitPoints, int posX, int posY) 
            : base(hitPoints, posX, posY)
        {
            _name = name;
        }
    }
}
