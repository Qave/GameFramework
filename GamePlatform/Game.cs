﻿using GameFramework;
using GameFramework.Factory;
using GameFramework.Handlers;
using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static GameFramework.Enums.MonsterTypes;
using static System.Console;

namespace GamePlatform
{
    /// <summary>
    /// Contains the game's elements, the world, the player, the monsters, bosses, exits, lootables, etc!
    /// </summary>
    public class Game
    {
        private World _world;
        private Player _player;
        private List<ICreature> monsters;

        public void Start() 
        {
            // Game Initialization

            // Console window title
            Title = "GameFramework";
            // instantiates the list of monsters, ready to be populated
            monsters = new List<ICreature>();
            // Create a new level
            string[,] grid = LevelParser.ParseTxtFileToArray("Levels/Level_one.txt");

            // Generate the World based on the grid
            _world = new World(grid);

            // Factory for creating creatures for the world. CAN include a player creature
            CreatureFactory fac = new CreatureFactory(_world);
            List<IWorldObject> t = _world.WorldObjects;

            // Generates the player. Since the method has a fixed position for the player, create the player first.
            _player = (Player)fac.CreateNewPlayer();

            // Generates a list of monsters to put into the world.
            monsters = fac.CreateNewMonsterList(4);





            RunGameLoop();
            //ReadKey(true);
        }
        private void DrawFrame()
        {
            CursorVisible = false;
            SetCursorPosition(0, 0);
            _world.Draw();
            _player.Draw();


            // draw all monsters
            foreach (ICreature monster in monsters)
            {
                monster.Draw();
            }

        }
        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (_world.IsNextPositionWalkable(_player.Position.PosX, _player.Position.PosY - 1))
                    {
                        _player.Position.PosY -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (_world.IsNextPositionWalkable(_player.Position.PosX, _player.Position.PosY + 1))
                    {
                        _player.Position.PosY += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (_world.IsNextPositionWalkable(_player.Position.PosX - 1, _player.Position.PosY))
                    {
                        _player.Position.PosX -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (_world.IsNextPositionWalkable(_player.Position.PosX + 1, _player.Position.PosY))
                    {
                        _player.Position.PosX += 1;
                    }
                    break;
                default:
                    break;
            }
        }
        private void RunGameLoop()
        {
            while (true)
            {
                //Draw everything
                DrawFrame();
                //Check for playerinput, then move the player or update accordingly
                HandlePlayerInput();
                //Check if the player has reached the exit and end the game if so
                string elementAtPlayerPosition = _world.GetElementAt(_player.Position.PosX, _player.Position.PosY);
                if (elementAtPlayerPosition == "X")
                {
                    Clear();
                    Console.WriteLine("You Won!");
                    ReadKey();
                }
                //Give the console a chance to render
                Thread.Sleep(20);
            }
        }
    }
}
