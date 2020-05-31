using NUnit.Framework;
using RobotCleaner.Domain.ValueObjects;
using RobotCleaner.Domain.Enumerator;
using RobotCleaner.Infrastructure.Repository.Repositories;

namespace RobotCleaner.Test
{
    public class DirectionsTest
    {
        
        [SetUp]
        public void TestInit()
        {
            
        }

        [Test]
        public void GetDirectionEOK()
        {
            RobotCleanerRepository test = new RobotCleanerRepository();
            Coordinate result = test.GetDirectionStep(Direction.E);

            Assert.AreEqual(1, result.X);
            Assert.AreEqual(0, result.Y);
        }

        [Test]
        public void GetDirectionENaoOK()
        {
            RobotCleanerRepository test = new RobotCleanerRepository();
            Coordinate result = test.GetDirectionStep(Direction.E);

            Assert.AreNotEqual(-1, result.X);
            Assert.AreNotEqual(1, result.Y);
        }

        [Test]
        public void GetDirectionWOK()
        {
            RobotCleanerRepository test = new RobotCleanerRepository();
            Coordinate result = test.GetDirectionStep(Direction.W);

            Assert.AreEqual(-1, result.X);
            Assert.AreEqual(0, result.Y);
        }

        [Test]
        public void GetDirectionWNaoOK()
        {
            RobotCleanerRepository test = new RobotCleanerRepository();
            Coordinate result = test.GetDirectionStep(Direction.W);

            Assert.AreNotEqual(1, result.X);
            Assert.AreNotEqual(1, result.Y);
        }

        [Test]
        public void GetDirectionSOK()
        {
            RobotCleanerRepository test = new RobotCleanerRepository();
            Coordinate result = test.GetDirectionStep(Direction.S);

            Assert.AreEqual(0, result.X);
            Assert.AreEqual(-1, result.Y);
        }

        [Test]
        public void GetDirectionSNaoOK()
        {
            RobotCleanerRepository test = new RobotCleanerRepository();
            Coordinate result = test.GetDirectionStep(Direction.S);

            Assert.AreNotEqual(1, result.X);
            Assert.AreNotEqual(1, result.Y);
        }

        [Test]
        public void GetDirectionNOK()
        {
            RobotCleanerRepository test = new RobotCleanerRepository();
            Coordinate result = test.GetDirectionStep(Direction.N);

            Assert.AreEqual(0, result.X);
            Assert.AreEqual(1, result.Y);
        }

        [Test]
        public void GetDirectionNNaoOK()
        {
            RobotCleanerRepository test = new RobotCleanerRepository();
            Coordinate result = test.GetDirectionStep(Direction.N);

            Assert.AreNotEqual(1, result.X);
            Assert.AreNotEqual(-1, result.Y);
        }
    }
}
