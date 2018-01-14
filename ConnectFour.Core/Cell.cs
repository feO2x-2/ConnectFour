using System;

namespace ConnectFour.Core
{
    public class Cell : ICell
    {
        private readonly int _x;
        private readonly int _y;

        public Cell(int x, int y)
        {
            if (x < 0)
                throw new ArgumentException("x cannot be less than zero.");
            if (y < 0)
                throw new ArgumentException("y cannot be less than zero.");

            _x = x;
            _y = y;
        }

        public Chip Chip { get; set; }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }
    }
}