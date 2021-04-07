using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static GameFramework.Enums.MonsterTypes;

namespace GameFramework.Factory
{
    public class CreatureFactory
    {
        private readonly Random rnd = new Random();
        private readonly World _world;
        public int WorldSizeX { get; set; }
        public int WorldSizeY { get; set; }

        public CreatureFactory(World world)
        {
            _world = world;
        }

        /// <summary>
        /// Creates a new monster
        /// </summary>
        /// <param name="monsterType">The monster type to create</param>
        /// <returns>Monster</returns>
        public ICreature CreateNewMonster(MonsterType monsterType)
        {
            return monsterType switch
            {
                MonsterType.Weak => new Monster(RndName(), MonsterType.Weak, (int)MonsterType.Weak, RndPos()),
                MonsterType.Normal => new Monster(RndName(), MonsterType.Normal, (int)MonsterType.Normal, RndPos()),
                MonsterType.Strong => new Monster(RndName(), MonsterType.Strong, (int)MonsterType.Strong, RndPos()),
                MonsterType.Boss => new Monster(RndName(), MonsterType.Boss, (int)MonsterType.Boss, RndPos()),
                // If its not a possible monster type, just return a weak creature
                _ => new Monster(RndName(), MonsterType.Weak, (int)MonsterType.Weak, RndPos()),
            };
        }

        public List<ICreature> CreateNewMonsterList(int noOfMonsters)
        {
            List<ICreature> monsterList = new List<ICreature>();
            for (int i = 0; i < noOfMonsters; i++)
            {
                ICreature temp = CreateNewMonster(GetRandomType());
                monsterList.Add(temp);
                _world.WorldObjects.Add(temp);
            }
            return monsterList;
        }


        // Not used
        public ICreature CreateNewPlayer()
        {
            ICreature temp = new Player("Qave", 400, RndPos());
            _world.WorldObjects.Add(temp);
            return temp;
        }

        private readonly List<string> MonsterNames = new List<string>()
        {
            "Mephisto","Baal","Diablo", "Andariel","Duriel","Lilith","Lucion"
        };
        private MonsterType GetRandomType()
        {
            var enums = Enum.GetValues(typeof(MonsterType));
            return (MonsterType)enums.GetValue(rnd.Next(1, enums.Length));
        }
        private string RndName()
        {
            Random rnd = new Random();
            return MonsterNames[rnd.Next(0, MonsterNames.Count)];
        }

        private Position RndPos()
        {
            // TODO
            // Generate a new pos, if new position is occupied or != " ", skip and try again. if loop is done, return "All possible positions have been filled." or something.. 

            return new Position(rnd.Next(1, _world.SizeX - 1), rnd.Next(1, _world.SizeY - 1));
        }
    }
}
