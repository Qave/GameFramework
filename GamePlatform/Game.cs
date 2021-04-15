using GameFramework;
using GameFramework.Factory;
using GameFramework.Handlers;
using GameFramework.Interfaces;
using GameFramework.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using static GameFramework.Enums.ItemTypes;
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
        private List<Item> _worldItems;

        public void Start() 
        {
            // Game Initialization
            // Console window title
            Title = "GameFramework";

            // Initiate logging
            TraceSource traceSource = new TraceSource("GameFramework_Tracing")
            {
                Switch = new SourceSwitch("EventTracing", "All")
            };

            TraceListener eventLog = new TextWriterTraceListener(new StreamWriter("Events.txt"));
            traceSource.Listeners.Add(eventLog);
            eventLog.Filter = new EventTypeFilter(SourceLevels.All);

            _worldItems = new List<Item>();

            // Create a new level
            string[,] grid = LevelParser.ParseTxtFileToArray("Levels/Level_one.txt");

            // Generate the World based on the grid
            _world = new World(grid);

            // Factory for creating creatures for the world. CAN include a player creature
            CreatureFactory creaturefac = new CreatureFactory(_world, traceSource);
            ItemFactory itemFac = new ItemFactory(_world, traceSource);

            // Generates the player. Since the method has a fixed position for the player, create the player first.
            _player = creaturefac.CreateNewPlayer();
            // Generates a list of monsters to put into the world.
            creaturefac.CreateNewMonsterList(4);

            _worldItems.Add(itemFac.GenerateItem(ItemType.Weapon));
            _worldItems.Add(itemFac.GenerateItem(ItemType.Armor));


            RunGameLoop();
            //ReadKey(true);
        }
        private void DrawFrame()
        {
            CursorVisible = false;
            SetCursorPosition(0, 0);
            _world.Draw();
            foreach (IWorldObject worldObject in _world.WorldObjects)
            {
                worldObject.Draw();
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
                FindWorldObjectAtPosition(_player.Position);
                //Give the console a chance to render
                Thread.Sleep(20);             
            }
        }


        private void FindWorldObjectAtPosition(Position playerPosition)
        {
            IWorldObject foundObject = null;

            var ElementAtPlayerPosition = _world.WorldObjects.FindAll(e => e.Position.PosX == playerPosition.PosX && e.Position.PosY == playerPosition.PosY);
            if (ElementAtPlayerPosition.Count() == 2)
            {
                foundObject = ElementAtPlayerPosition.Where(e => e != _player).Single();

                switch (foundObject)
                {
                    case Monster monster:
                        EnterCombat(_player, monster);
                        break;
                    case Item item:
                        _world.WorldObjects.Remove(item);
                        _player.PickUpItem(item);
                        break;
                    default:
                        break;
                }
            }       
        }

        private void EnterCombat(Player player, Monster monster)
        {
            Clear();
            WriteLine("Entering combat...");
            Thread.Sleep(500);
            while (player.IsDead != true) 
            {
                _player.Attacks(monster);
                Thread.Sleep(500);

                if (monster.IsDead)
                {
                    WriteLine($"{player.Name} has defeated {monster.Name}");
                    WriteLine("Press any key to continue...");
                    _world.WorldObjects.Remove(monster);
                    ReadKey();
                    break;
                }
                else
                {
                    monster.Attacks(_player);
                    Thread.Sleep(500);
                }
            }
            if (player.IsDead)
            {
                WriteLine($"You have been defeated. Press any key to close the application");
                ReadKey();
            }
            Clear();
        }

    }
}
