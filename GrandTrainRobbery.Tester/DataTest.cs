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
                p.X==-1 &&
                p.Y==-1 &&
                p.Name=="CorrectName"
                );
               
            
        }
        [Test]
        public static void MapInstatiation()
        {
            Assert.That(true);
        }
    }
}
