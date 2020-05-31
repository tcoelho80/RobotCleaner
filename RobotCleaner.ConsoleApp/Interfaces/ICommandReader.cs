using System;
using System.Collections.Generic;
using System.Text;
using RobotCleaner.Domain.ValueObjects;

namespace RobotCleaner.ConsoleApp.Interfaces
{
    public interface ICommandReader
    {
        int ReadAmountOfCommands();
        CleanningProcess ReadAllCommands();
    }
}
