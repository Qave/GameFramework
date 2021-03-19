using GameFramework;
using GameFramework.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

        public void Start()
        {
            string[,] grid = LevelParser.ParseTxtFileToArray("Levels/Level_one.txt");
            Title = "GameFramework";

            _world = new World(grid);

            _player = new Player("Niels", 140, new Position(1, 1));

            RunGameLoop();
            //ReadKey(true);        
        }
        private void DrawFrame()
        {
            CursorVisible = false;
            SetCursorPosition(0, 0);
            //Clear();
            _world.Draw();
            _player.Draw();
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
