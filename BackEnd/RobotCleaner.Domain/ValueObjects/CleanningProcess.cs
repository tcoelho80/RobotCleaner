using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleaner.Domain.ValueObjects
{
    public class CleanningProcess
    {
        private Coordinate _startingCoordinate;
        private List<MoveCommand> _commands;

        public Coordinate StartingCoordinate { get { return _startingCoordinate; } }
        public List<MoveCommand> Commands { get { return _commands; } }
        public CleanningProcess(Coordinate startingCoordinate, List<MoveCommand> commands)
        {
            this._startingCoordinate = startingCoordinate;
            this._commands = commands;
        }
    }
}
