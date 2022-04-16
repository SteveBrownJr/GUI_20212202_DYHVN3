using GrandTrainRobbery.Data;
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
            Console.WriteLine(testableDB.GetPlayer);
            
        }
    }
}
