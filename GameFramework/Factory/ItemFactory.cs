using GameFramework.Items;
using GameFramework.Items.ConcreteArmor;
using GameFramework.Items.ConcreteWeapon;
using GameFramework.Items.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static GameFramework.Enums.ItemTypes;

namespace GameFramework.Factory
{
    public class ItemFactory : AbstractFactory
    {
        public ItemFactory(World world, TraceSource traceSource) : base(world, traceSource)
        {
        }

        public Item GenerateItem(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Weapon:
                    Sword returnedSword = new Sword(30, "Short Sword", ItemType.Weapon, RndPos());
                    TraceSource.TraceEvent(TraceEventType.Information, 50, $"Placed item {returnedSword.Name} in the world, at x{returnedSword.Position.PosX},y{returnedSword.Position.PosY}");
                    TraceSource.Flush();
                    _world.WorldObjects.Add(returnedSword);
                    return returnedSword;
                case ItemType.Armor:
                    ChestArmor returnedArmor = new ChestArmor(50, "Low Quality Breastplate", ItemType.Armor, RndPos());
                    TraceSource.TraceEvent(TraceEventType.Information, 50, $"Placed item {returnedArmor.Name} in the world, at x{returnedArmor.Position.PosX},y{returnedArmor.Position.PosY}");
                    TraceSource.Flush();
                    _world.WorldObjects.Add(returnedArmor);
                    return returnedArmor;
                default:
                    return null;
            }
            
        }
    }
}
