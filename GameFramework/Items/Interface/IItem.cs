using GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework.Items.Interface
{
    public interface IItem : IWorldObject
    {
        // for now all items are equippable, if not, create interface IEquippable
    }
}
