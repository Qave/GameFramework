using GameFramework.Decorators.Concrete;
using GameFramework.Interfaces;
using GameFramework.Items.ConcreteArmor;
using GameFramework.Items.ConcreteWeapon;
using GameFramework.Items.Interface;
using GameFramework.Logging.Interface;
using GameFramework.Observer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Console;

namespace GameFramework
{
    public abstract class Creature : ICreature
    {
        //Private Fields
        protected string _name;
        protected int _hitPoints;
        protected bool _isDead = false;
        protected int _damage;
        protected double _defence;
        protected Position _position;


        //public List<IItem> Items { get; set; } = new List<IItem>(); // > ICreature > IItem
        public Creature(string name, int hitPoints, Position position)
        {
            _name = name;
            _damage = 10;
            _defence = 50;
            _isDead = false;
            _hitPoints = hitPoints;
            _position = position;        
        }

        public int HitPoints { 
            get 
            {
                return _hitPoints;
            }
            set
            { 
                _hitPoints = value;
                if (_hitPoints < 0)
                {
                    _hitPoints = 0;
                    CreatureObserver.OnDeath(this);
                }
            } 
        }
        public bool IsDead { get { return _isDead; } set { _isDead = value; } }
        public int Damage { get { return _damage; } 
            set 
            { 
                _damage = value;              
            }
        }
        public string Name { get { return _name; } set { _name = value; } }
        public double Defence { get { return _defence; } set { _defence = value; } }
        public Position Position { get { return _position; } set { _position = value; } }




        // Abstract methods
        public abstract void AddDamage();
        //public void Draw(ConsoleColor color, string marker)
        //{
        //    ForegroundColor = color;
        //    SetCursorPosition(this.Position.PosX, this.Position.PosY);
        //    Write(marker);
        //    ResetColor();
        //}
        public abstract void Draw();

        public void Attacks(ICreature creature)
        {
            int calculatedDmg = CalculateDamage(this.Damage);
            creature.HitPoints -= calculatedDmg;
            WriteLine($"{Name} attacks {creature.Name} for {calculatedDmg} damage. {creature.Name} has {creature.HitPoints} left.");
        }
        public int CalculateDamage(int damageReceived)
        {
            int calculatedDamage = Convert.ToInt32(Math.Floor(damageReceived*(100 / (100 + this.Defence))));

            return calculatedDamage;

        }

        public void PickUpItem(IItem item)
        {
            switch (item)
            {
                case Sword sword:
                    _damage += sword.AttackPower;
                    break;
                case ChestArmor chest:
                    _defence += chest.BaseDefense;
                    break;
                default:
                    break;
            }
        }
    }
}
