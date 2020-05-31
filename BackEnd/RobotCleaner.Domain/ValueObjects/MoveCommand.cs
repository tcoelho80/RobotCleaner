using RobotCleaner.Domain.Enumerator;

namespace RobotCleaner.Domain.ValueObjects
{
    public class MoveCommand
    {
        private Direction _direction;

        public Direction Direction
        {
            get { return _direction; }
        }

        private int _steps;
        public MoveCommand(Direction direction, int steps)
        {
            _direction = direction;
            _steps = steps;
        }

        public int Steps
        {
            get { return _steps; }
        }
    }
}
