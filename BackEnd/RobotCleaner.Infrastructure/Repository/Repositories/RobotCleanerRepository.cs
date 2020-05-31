using RobotCleaner.Domain.Interfaces;
using RobotCleaner.Domain.ValueObjects;
using RobotCleaner.Domain.Enumerator;
using System.Collections.Generic;
using System;

namespace RobotCleaner.Infrastructure.Repository.Repositories
{
    public class RobotCleanerRepository : IRobotCleanerRepository
    {
        private Coordinate _startingCoordinate;
        private List<MoveCommand> _commands;

        public RobotCleanerRepository()
        {
            
        }

        public Coordinate GetDirectionStep(Direction direction)
        {
            return _mapDirectionCoordinate[direction];
        }

        public Direction GetDirection(string p)
        {
            return _mapDirectionName[p];
        }

        private static Dictionary<Direction, Coordinate> _mapDirectionCoordinate = new Dictionary<Direction, Coordinate>
        {
            {Direction.N, new Coordinate(0, 1)},
            {Direction.S, new Coordinate(0, -1)},
            {Direction.E, new Coordinate(1, 0)},
            {Direction.W, new Coordinate(-1, 0)}
        };

        private static Dictionary<String, Direction> _mapDirectionName = new Dictionary<String, Direction>
        {
            {"N", Direction.N},
            {"S", Direction.S},
            {"E", Direction.E},
            {"W", Direction.W}
        };

        


    }
}
