using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Handlers
{
    public class MonsterHandler
    {
        public static List<Monster> CreateMonsters()
        {
            List<Monster> _monsters = new List<Monster>();
            
            int AmountOfMonsters = rnd.Next(2, 5); // ska hentes fra Xml Config
            for (int i = 0; i < AmountOfMonsters; i++)
            {
                _monsters.Add(new Monster(
                    RndName(),
                    (Monster._Type)rnd.Next(0, 3),
                    GetInitialHitPoints(rnd.Next(1, 4)),
                    rnd.Next(1, worldSizeX),
                    rnd.Next(1, worldSizeY)
                    ));
            }
            return _monsters;
        }

        // Private Methods and properties
        private static Random rnd = new Random();
        private static int worldSizeX = 20; // Hent worldsize fra XML Config
        private static int worldSizeY = 20;
        private static int GetInitialHitPoints(int No)
        {
            switch (No)
            {
                case 1: // Weak
                    return (int)Monster._Type.Weak;
                case 2: // Normal
                    return (int)Monster._Type.Normal;
                case 3: // Strong
                    return (int)Monster._Type.Strong;
                case 4: // Boss
                    return (int)Monster._Type.Boss;
                default:
                    return (int)Monster._Type.Weak;
            }
        }
        private static List<string> MonsterNames = new List<string>()
        {
            "Mephisto","Baal","Diablo", "Andariel","Duriel","Lilith","Izual","Lucion"
        };
        private static string RndName()
        {
            Random rnd = new Random();
            return MonsterNames[rnd.Next(0, MonsterNames.Count)];
        }
    }
}
