using GameFramework;
using GameFramework.Decorators.Concrete;
using GameFramework.Interfaces;
using GameFramework.Items;
using GameFramework.Items.ConcreteArmor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static GameFramework.Enums.ItemTypes;
using static GameFramework.Enums.MonsterTypes;

namespace TestGameFramework
{
    [TestClass]
    public class TestFramework
    {
        Creature player;
        Monster monster;
        Sword testItem;
        //World world;
        [TestInitialize]
        public void TestSetup()
        {
            player = new Player("Tester", 400, new Position(2, 10));
            monster = new Monster("TestMonster", MonsterType.Normal, (int)MonsterType.Normal, new Position(4, 10));
            testItem = new Sword(20, "TestSword", ItemType.Weapon, new Position(4, 10));
            
            //world = new World(new string[20,20]);
        }
        [TestMethod]
        public void TestBaseAttack()
        {
            Assert.AreEqual(10, player.Damage);
        }
        [TestMethod]
        public void TestAttackDecorator()
        {
            player = new AttackDecorator("",10, player);
            player.AddDamage();
            Assert.AreEqual(20, player.Damage);
        }
        [TestMethod]
        public void TestAttacking()
        {              
            player.Attacks(monster);
            Assert.AreEqual(194, monster.HitPoints);
        }
        [TestMethod]
        public void TestPickUpItem()
        {

            player.PickUpItem(testItem);
            Assert.AreEqual(30, player.Damage);
        }
    }
}
