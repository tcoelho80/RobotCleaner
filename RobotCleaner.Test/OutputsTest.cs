using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using RobotCleaner.ConsoleApp.Interfaces;
using RobotCleaner.ConsoleApp;
using RobotCleaner.AppServices.Interfaces;
using RobotCleaner.Domain.ValueObjects;

namespace RobotCleaner.Test
{
    [TestFixture]
    public class OutputsTest
    {
        Mock<IView> _mockView;
        Mock<IRobotCleanerServices> _mockRobotCleanerServices;
        Mock<ICommandReader> _mockCommandReader;

        [SetUp]
        public void TestInit()
        {
            _mockView = new Mock<IView>();
            _mockRobotCleanerServices = new Mock<IRobotCleanerServices>();
            _mockCommandReader = new Mock<ICommandReader>();
        }

        [Test]
        public void TestOutOk()
        {
            Controller test = new Controller(_mockView.Object, _mockCommandReader.Object, _mockRobotCleanerServices.Object);
            _mockCommandReader.Setup(x => x.ReadAllCommands()).Returns(new CleanningProcess(
                new Coordinate(0, 0), new List<MoveCommand>()));

            _mockRobotCleanerServices.Setup(x => x.ExecuteClean(It.IsAny<CleanningProcess>())).Returns(1001);
            _mockView.Setup(x => x.WriteLine(It.IsAny<String>()));

            test.Run();

            _mockView.Verify(w => w.WriteLine(It.Is<string>(s => s == "=>Cleaned: 1001")), Times.Once);
        }
    }
}
