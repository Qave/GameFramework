using GameFramework.Factory;
using GameFramework.Interfaces;
using GameFramework.Observer;
using GameFramework.Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace GameFramework
{
    public class World : IObserver
    {

        // On world creation, initialize a random amount of monsters, lootables, maybe walls?? and an exit ?? / unlock after killing boss?
        // Handle staging inside this class, statically, more mobs per stage?

        // Private Fields
        private readonly string[,] _grid;
        private int _rows;
        private int _cols;
        //private IWorldObject _worldObject;
        //private static int _stage = 0;

        //Public Properties
        public int SizeY { get => _rows; set { _rows = value; } }
        public int SizeX { get => _cols; set { _cols = value; } }

        public List<IWorldObject> WorldObjects { get; set; }

        //Dependencies
        public Creature _creature;
        public Player _player;
        public List<Monster> _monsters;
        public CreatureObserver CreatureObserver { get; set; } = new CreatureObserver();

        /// <summary>
        /// World Creation
        /// </summary>
        /// <param name="sizeY">The height of your world</param>
        /// <param name="sizeX">The width of your world</param>
        /// <param name="worldLevel">The world level. To be implemented</param>
        public World(string[,] grid)
        {
            WorldObjects = new List<IWorldObject>();

            // World size, playername ka hentes fra Xml Config
            //_monsters = monsters;
            //_player = player;
            _grid = grid;
            _rows = grid.GetLength(0);
            _cols = grid.GetLength(1);
            CreatureObserver.Add(this);

        }
        public void Draw()
        {
            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _cols; x++)
                {
                    string el = _grid[y, x];
                    SetCursorPosition(x, y);
                    Write(el);
                }
            }
        }
        /// <summary>
        /// Checks if the next position is walkable
        /// </summary>
        /// <param name="x">The X position in the grid</param>
        /// <param name="y">The Y position in the grid</param>
        /// <returns></returns>
        public bool IsNextPositionWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _cols || y >= _rows)
            {
                return false;
            }
            return _grid[y, x] == " ";
        }

        public void Notify(ICreature creature)
        {
            // Gets notified that a creature in the world has changed.
            creature.IsDead = true;
            
        }
    }
}
