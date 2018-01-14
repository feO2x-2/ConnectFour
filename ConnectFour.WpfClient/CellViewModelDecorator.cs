using System;
using System.Windows.Input;
using ConnectFour.Core;

namespace ConnectFour.WpfClient
{
    public class CellViewModelDecorator : BaseViewModel, ICell
    {
        private readonly ICell _cell;
        private readonly FunctionalCommand _clickCellCommand;

        public CellViewModelDecorator(ICell cell)
        {
            if (cell == null) throw new ArgumentNullException("cell");

            _cell = cell;
            _clickCellCommand = new FunctionalCommand(RaiseCellClicked);
        }

        private void RaiseCellClicked()
        {
            if (CellClicked != null)
                CellClicked(this);
        }

        public ICommand ClickCellCommand
        {
            get { return _clickCellCommand; }
        }

        public Chip Chip
        {
            get { return _cell.Chip; }
            set
            {
                if (value == _cell.Chip)
                    return;

                _cell.Chip = value;
                OnPropertyChanged();
            }
        }

        public int X
        {
            get { return _cell.X; }
        }

        public int Y
        {
            get { return _cell.Y; }
        }

        public event Action<ICell> CellClicked;
    }
}