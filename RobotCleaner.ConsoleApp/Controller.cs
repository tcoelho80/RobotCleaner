using RobotCleaner.AppServices.Interfaces;
using RobotCleaner.ConsoleApp.Interfaces;
using RobotCleaner.Domain.ValueObjects;

namespace RobotCleaner.ConsoleApp
{
    public class Controller
    {
        IView _view;
        ICommandReader _reader;
        IRobotCleanerServices _robotCleanerServices;
        public Controller(IView view, ICommandReader reader, IRobotCleanerServices robotCleanerServices)
        {
            _view = view;
            _reader = reader;
            _robotCleanerServices = robotCleanerServices;
        }

        public void Run()
        {
            CleanningProcess cleanningProcess = _reader.ReadAllCommands();
            int placesClean = _robotCleanerServices.ExecuteClean(cleanningProcess);
            _view.WriteLine(string.Format(Resources.ResultLabel, placesClean));
        }

    }
}
