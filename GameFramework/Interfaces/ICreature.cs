using GameFramework.Items.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Interfaces
{
    public interface ICreature : IWorldObject
    {
        List<IItem> Items { get; set; }
        int HitPoints { get; set; }
        bool IsDead { get; set; }
        int Damage { get; set; }
        double Defence { get; set; }
        void Draw();
        void Attacks(ICreature creature);
        int CalculateDamage(int damageReceived);
    }
}
