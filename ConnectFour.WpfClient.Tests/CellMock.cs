using ConnectFour.Core;

namespace ConnectFour.WpfClient.Tests
{
    public class CellMock : ICell
    {
        private Chip _chip;
        private int _numberOfSetChipCalls;

        public CellMock(int x = -1, int y = -1)
        {
            X = x;
            Y = y;
        }

        public Chip Chip
        {
            get { return _chip; }
            set
            {
                _numberOfSetChipCalls++;
                _chip = value;
            }
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public int NumberOfSetChipCalls
        {
            get { return _numberOfSetChipCalls; }
            set { _numberOfSetChipCalls = value; }
        }
    }
}