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
        double Damage { get; set; }
        double Defence { get; set; }
        void Draw();
    }
}
