using RobotCleaner.Domain.Enumerator;
using RobotCleaner.Domain.ValueObjects;
using System.Collections.Generic;


namespace RobotCleaner.AppServices.Interfaces
{
    public interface IRobotCleanerServices
    {
        int ExecuteClean(CleanningProcess cleanningProcess);
    }
}
