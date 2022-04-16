using GrandTrainRobbery.Physics;
using NUnit.Framework;
using System;

namespace GrandTrainRobbery.Tester
{
    [TestFixture]
    public class PhysicsTests
    {
        [Test]
        public static void Test1()
        {
            GamePhysics TesterGamePhysics = new GamePhysics(new System.Collections.Generic.List<Models.IEntity>());
        }
    }
}
