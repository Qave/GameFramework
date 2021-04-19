using GameFramework.Config;
using GameFramework.Interfaces;
using GameFramework.Logging;
using GameFramework.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static GameFramework.Enums.MonsterTypes;

namespace GameFramework.Factory
{
    public class CreatureFactory : AbstractFactory, ITracing
    {
        private readonly Random _rnd = new Random();
        private readonly GameConfig _conf = ConfigSingleton.Instance.GameConfig;

        public int WorldSizeX { get; set; }
        public int WorldSizeY { get; set; }

        public CreatureFactory(World world, TraceSource traceSource) : base(world, traceSource)
        {
        }

        public Player CreateNewPlayer()
        {
            Player temp = new Player(_conf.PlayerName, 200, new Position(1, 2));
            _world.WorldObjects.Add(temp);
            TraceSource.TraceEvent(TraceEventType.Information, 1, $"Created player: {temp.Name} at position: {temp.Position.PosX},{temp.Position.PosY}");
            TraceSource.Flush();
            return temp;
        }

        /// <summary>
        /// Creates a new monster
        /// </summary>
        /// <param name="monsterType">The monster type to create</param>
        /// <returns>Monster</returns>
        public Monster CreateNewMonster(MonsterType monsterType)
        {
            Monster returnedMonster = new Monster("Default", MonsterType.Weak, (int)MonsterType.Weak, RndPos());
            switch (monsterType)
            {
                case MonsterType.Weak:
                    returnedMonster = new Monster(RndName(), MonsterType.Weak, (int) MonsterType.Weak, RndPos());
                    break;
                case MonsterType.Normal:
                    returnedMonster = new Monster(RndName(), MonsterType.Normal, (int)MonsterType.Normal, RndPos());
                    break;
                case MonsterType.Strong:
                    returnedMonster = new Monster(RndName(), MonsterType.Strong, (int)MonsterType.Strong, RndPos());
                    break;
                case MonsterType.Boss:
                    returnedMonster = new Monster(RndName(), MonsterType.Boss, (int)MonsterType.Boss, RndPos());
                    break;
                default:
                    TraceSource.TraceEvent(TraceEventType.Information, 3, $"No monster of the specified type, created default monster instead at position: {returnedMonster.Position.PosX},{returnedMonster.Position.PosY}");
                    return returnedMonster;
            }
            TraceSource.TraceEvent(TraceEventType.Information, 2, $"Created monster: {returnedMonster.Name} at position: {returnedMonster.Position.PosX},{returnedMonster.Position.PosY}");
            TraceSource.Flush();
            return returnedMonster;

        }
        public void CreateNewMonsterList(int noOfMonsters)
        {
            for (int i = 0; i < noOfMonsters; i++)
            {
                Monster temp = CreateNewMonster(GetRandomType());
                _world.WorldObjects.Add(temp);
            }
        }      

        private readonly List<string> MonsterNames = new List<string>()
        {
            "Mephisto","Baal","Diablo", "Andariel","Duriel","Lilith","Lucion"
        };
        private MonsterType GetRandomType()
        {
            var enums = Enum.GetValues(typeof(MonsterType));

            return (MonsterType)enums.GetValue(_rnd.Next(1, enums.Length));
        }
        private string RndName()
        {
            Random rnd = new Random();
            return MonsterNames[rnd.Next(0, MonsterNames.Count)];
        }

        
    }
}
