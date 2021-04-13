using GameFramework;
using GameFramework.Decorators.Concrete;
using GameFramework.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGameFramework
{
    [TestClass]
    public class TestFramework
    {
        Creature player;
        //World world;
        [TestInitialize]
        public void TestSetup()
        {
            player = new Player("Tester", 400, new Position(2, 10));
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
            player = new AttackDecorator(player);
            player.AddDamage();
            Assert.AreEqual(20, player.Damage);
        }
    }
}
