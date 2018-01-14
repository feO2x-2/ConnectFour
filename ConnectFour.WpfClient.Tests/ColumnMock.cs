using ConnectFour.Core;

namespace ConnectFour.WpfClient.Tests
{
    public class ColumnMock : IColumn
    {
        private int _numberOfSetChipCalls;
        private readonly int _index;

        public ColumnMock(int index = 0)
        {
            _index = index;
        }

        public void SetChip(Chip spielstein)
        {
            _numberOfSetChipCalls++;
        }

        public bool IsFull { get; set; }

        public int Index
        {
            get { return _index; }
        }

        public ICell NextEmptyCell { get; private set; }

        public bool WasSetChipCalledExactlyOnce
        {
            get { return _numberOfSetChipCalls == 1; }
        }
    }
}