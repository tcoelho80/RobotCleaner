using RobotCleaner.ConsoleApp.Interfaces;
using RobotCleaner.Domain.Interfaces;
using RobotCleaner.Infrastructure.Repository.Repositories;
using RobotCleaner.AppServices.Interfaces;
using RobotCleaner.AppServices.Services;
using System;

namespace RobotCleaner.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IRobotCleanerRepository robotCleanerRepository = new RobotCleanerRepository();
            IView view = new View();
            IRobotCleanerServices robotCleanerServices = new RobotCleanerServices(robotCleanerRepository);
            ICommandReader reader = new CommandReader(view, robotCleanerServices);
            Controller controller = new Controller(view, reader, robotCleanerServices);
            controller.Run();
        }
    }
}
