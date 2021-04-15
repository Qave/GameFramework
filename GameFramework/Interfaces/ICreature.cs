using GameFramework.Items.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Interfaces
{
    public interface ICreature : IWorldObject
    {
        //List<IItem> Items { get; set; }
        string Name { get; set; }
        int HitPoints { get; set; }
        bool IsDead { get; set; }
        int Damage { get; set; }
        double Defence { get; set; }
        void Attacks(ICreature creature);
        int CalculateDamage(int damageReceived);
        void PickUpItem(IItem item);
    }
}
