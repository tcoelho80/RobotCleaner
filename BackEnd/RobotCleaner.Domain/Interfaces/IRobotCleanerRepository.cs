using System.Collections.Generic;
using RobotCleaner.Domain;
using RobotCleaner.Domain.Enumerator;
using RobotCleaner.Domain.ValueObjects;

namespace RobotCleaner.Domain.Interfaces
{
    public interface IRobotCleanerRepository
    {
        Coordinate GetDirectionStep(Direction direction);
        Direction GetDirection(string p);

    }
}
