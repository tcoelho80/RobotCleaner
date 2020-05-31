using RobotCleaner.ConsoleApp.Interfaces;
using RobotCleaner.Domain.ValueObjects;
using System.Collections.Generic;
using RobotCleaner.AppServices.Interfaces;
using RobotCleaner.Domain.Enumerator;
using System;

namespace RobotCleaner.ConsoleApp
{
    public class CommandReader : ICommandReader
    {

        IView _view;
        IRobotCleanerServices _robotCleanerServices;

        public CommandReader(IView view, IRobotCleanerServices robotCleanerServices)
        {
            _view = view;
            _robotCleanerServices = robotCleanerServices;
        }
        public int ReadAmountOfCommands()
        {
            return int.Parse(_view.ReadLine());
        }

        public Coordinate ReadStartingCoordinate()
        {
            string line = _view.ReadLine();
            string[] coordinates = line.Split(' ');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);
            return new Coordinate(x, y);
        }

        public MoveCommand ReadCommand()
        {
            string line = _view.ReadLine();
            string[] details = line.Split(' ');
            return new MoveCommand(Enum.Parse<Direction>(details[0]), int.Parse(details[1]));
        }
        public CleanningProcess ReadAllCommands()
        {
            int amountOfCommands = this.ReadAmountOfCommands();
            Coordinate startingCoordinate = this.ReadStartingCoordinate();
            List<MoveCommand> commands = new List<MoveCommand>();
            while (commands.Count < amountOfCommands)
            {
                commands.Add(this.ReadCommand());
            }
            CleanningProcess cleanningProcess = new CleanningProcess(startingCoordinate, commands);
            return cleanningProcess;
        }
    }
}
