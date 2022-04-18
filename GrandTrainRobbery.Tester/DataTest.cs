using GrandTrainRobbery.Data;
using GrandTrainRobbery.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Tester
{
    [TestFixture]
    class DataTest
    {
        [Test]
        public static void PlayerInstatiation()
        {
            GameDB testableDB = new GameDB(0);
            Player p = testableDB.GetPlayer;
            Assert.That(p.Name == "CorrectName" &&
                p.Id == 0 &&
                p.Description == "CorrectDescription" &&
                p.ChrouchTexturePath == "CorrectChrouchTexture"&&
                p.TexturePath == "CorrectTexture"&&
                p.MeleeTexturePath=="CorrectMeleeAttack"&&
                p.AttackTexturePath=="CorrectRangedAttack"&&
                p.RunTexturePath== "CorrectRunTexture"&&
                p.JumpTexturePath== "CorrectJumpTexture" &&
                p.X==-1 &&
                p.Y==-1
                );
        }
        [Test]
        public static void MapInstatiation()
        {
            GameDB testableDB = new GameDB(0);
            Map m = testableDB.GetWagon;
            Assert.That(
                m.Ceiling==0&&
                m.Floor==100&&
                m.LeftCorner==0&&
                m.RightCorner==100&&
                m.LevelPath== "CorrectTexture");
        }
        [Test]
        public static void ChestInstation()
        {
            GameDB testableDB = new GameDB(0);
            Chest c = testableDB.GetChest;
            Assert.That(
                true);
        }
        [Test]
        public static void MOBInstatiation()
        {
            GameDB testableDB = new GameDB(0);
            MOB m = testableDB.GetEntitys.First() as MOB;
            Assert.That(
                m.Id==1&&
                m.Name== "CorrectMOBName"&&
                m.TexturePath== "CorrectMOBTexture"&&
                m.RunTexturePath== "CorrectMOBRunTexture"&&
                m.JumpTexturePath== "CorrectMOBJumpTexture"&&
                m.MeleeTexturePath== "CorrectMOBMeleeAttack"&&
                m.AttackTexturePath == "CorrectMOBRangedAttack"&&
                m.ChrouchTexturePath== "CorrectMOBChrouchTexture"&&
                m.Description== "CorrectMOBDescription"&&
                m.X==-1 &&
                m.Y==-1
                );
        }

    }
}
