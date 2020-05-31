using NUnit.Framework;
using Moq;
using RobotCleaner.ConsoleApp.Interfaces;
using RobotCleaner.ConsoleApp;
using RobotCleaner.AppServices.Interfaces;
using RobotCleaner.Domain.ValueObjects;
using RobotCleaner.Domain.Enumerator;


namespace RobotCleaner.Test
{
    [TestFixture]
    public class EntriesTest
    {
        Mock<IView> _mockView;
        Mock<IRobotCleanerServices> _mockRobotCleanerServices;

        [SetUp]
        public void TestInit()
        {
            _mockView = new Mock<IView>();
            _mockRobotCleanerServices = new Mock<IRobotCleanerServices>();
        }

        [Test]
        public void TestFirstLineOK()
        {
            CommandReader test = new CommandReader(_mockView.Object, _mockRobotCleanerServices.Object);
            _mockView.Setup(x => x.ReadLine()).Returns("2");
            int result = test.ReadAmountOfCommands();

            Assert.AreEqual(2, result);
        }

        [Test]
        public void TestCoordinatesOK()
        {
            CommandReader test = new CommandReader(_mockView.Object, _mockRobotCleanerServices.Object);
            _mockView.Setup(x => x.ReadLine()).Returns("10 22");
            Coordinate result = test.ReadStartingCoordinate();

            Assert.AreEqual(10, result.X);
            Assert.AreEqual(22, result.Y);
        }

        
        [Test]
        public void TestDirectionEtapsOk()
        {
            CommandReader test = new CommandReader(_mockView.Object, _mockRobotCleanerServices.Object);
            _mockView.Setup(x => x.ReadLine()).Returns("E 2");
            MoveCommand result = test.ReadCommand();

            Assert.AreEqual(Direction.E, result.Direction);
            Assert.AreEqual(2, result.Steps);
        }

        [Test]
        public void ReadAllCommand_text_sequence_input_should_return_CleanningSession()
        {
            CommandReader test = new CommandReader(_mockView.Object, _mockRobotCleanerServices.Object);
            _mockView.SetupSequence(x => x.ReadLine())
                .Returns("2")
                .Returns("10 22")
                .Returns("E 2")
                .Returns("N 1");
            CleanningProcess result = test.ReadAllCommands();

            Assert.AreEqual(2, result.Commands.Count);

            Assert.AreEqual(10, result.StartingCoordinate.X);
            Assert.AreEqual(22, result.StartingCoordinate.Y);
            
            Assert.AreEqual(Direction.E, result.Commands[0].Direction);
            Assert.AreEqual(2, result.Commands[0].Steps);

            Assert.AreEqual(Direction.N, result.Commands[1].Direction);
            Assert.AreEqual(1, result.Commands[1].Steps);
        }

        

    }
}
