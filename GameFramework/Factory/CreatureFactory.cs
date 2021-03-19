using System;
using System.Collections.Generic;
using System.Text;
using static GameFramework.Enums.MonsterTypes;

namespace GameFramework.Factory
{
    public class CreatureFactory
    {
        private readonly Random rnd = new Random();
        private readonly int worldSizeX = 20; // Hent worldsize fra XML Config
        private readonly int worldSizeY = 20;

        /// <summary>
        /// Creates a new monster
        /// </summary>
        /// <param name="monsterType">The monster type to create</param>
        /// <returns>Monster</returns>
        public Creature CreateNewMonster(MonsterType monsterType)
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

        public Creature CreateNewPlayer()
        {         
            return new Player("KASPOR", 400, RndPos());
        }






        private readonly List<string> MonsterNames = new List<string>()
        {
            "Mephisto","Baal","Diablo", "Andariel","Duriel","Lilith","Lucion"
        };
        private string RndName()
        {
            Random rnd = new Random();
            return MonsterNames[rnd.Next(0, MonsterNames.Count)];
        }
        private Position RndPos()
        {
            return new Position(rnd.Next(1, worldSizeX), rnd.Next(1, worldSizeY));
        }
    }
}
