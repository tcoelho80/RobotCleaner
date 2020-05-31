using AutoMapper;
using RobotCleaner.AppServices.Interfaces;
using RobotCleaner.Domain.Enumerator;
using RobotCleaner.Domain.ValueObjects;
using RobotCleaner.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;

namespace RobotCleaner.AppServices.Services
{
    public class RobotCleanerServices : IRobotCleanerServices
    {
        private readonly IRobotCleanerRepository _robotCleanerRepository;
        private Coordinate _currentPosition;
        private Dictionary<Coordinate, bool> _cleanOffices;

        public RobotCleanerServices(IRobotCleanerRepository robotCleanerRepository)
        {
            _robotCleanerRepository = robotCleanerRepository;
            _cleanOffices = new Dictionary<Coordinate, bool>();
        }

        public int ExecuteClean(CleanningProcess cleanningProcess)
        {
            GoTo(cleanningProcess.StartingCoordinate);
            foreach (var command in cleanningProcess.Commands)
            {
                this.MoveTowards(command.Direction, command.Steps);
            }
            return _cleanOffices.Count;
        }
        
        private void GoTo(Coordinate position)
        {
            CurrentPosition = position;
        }

        private Coordinate CurrentPosition
        {
            get { return _currentPosition; }
            set
            {
                _currentPosition = value;
                CleanCurrentPosition();
            }
        }       

        private void CleanCurrentPosition()
        {
            _cleanOffices[_currentPosition] = true;
        }

        private void MoveTowards(Direction direction, int steps)
        {
            Coordinate directionStep = _robotCleanerRepository.GetDirectionStep(direction);
            for (int i = 0; i < steps; i++)
            {
                CurrentPosition = new Coordinate(_currentPosition.X + directionStep.X, _currentPosition.Y + directionStep.Y);
            }
        }

        



    }
}
