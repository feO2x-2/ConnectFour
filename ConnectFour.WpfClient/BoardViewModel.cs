using System;
using System.Collections.Generic;
using System.Linq;
using ConnectFour.Core;

namespace ConnectFour.WpfClient
{
    public class BoardViewModel : IBoardViewModel
    {
        private readonly IReadOnlyList<CellViewModelDecorator> _cells;
        private readonly IReadOnlyCollection<IClickColumnCommand> _clickColumnCommands;
        private readonly IReadOnlyList<IColumn> _columns;

        public BoardViewModel(IReadOnlyList<CellViewModelDecorator> cells,
                              IReadOnlyCollection<IClickColumnCommand> clickColumnCommands,
                              IReadOnlyList<IColumn> columns)
        {
            if (cells == null) throw new ArgumentNullException("cells");
            if (clickColumnCommands == null) throw new ArgumentNullException("clickColumnCommands");
            if (columns == null) throw new ArgumentNullException("columns");

            _cells = cells;
            _clickColumnCommands = clickColumnCommands;
            _columns = columns;

            foreach (var cell in cells)
                cell.CellClicked += RaiseColumnCommandIfPossible;
        }

        private void RaiseColumnCommandIfPossible(ICell cell)
        {
            var correspondingColumn = _columns[cell.X];
            if (correspondingColumn.NextEmptyCell != cell)
                return;

            var targetCommand = _clickColumnCommands.First(command => command.ColumnIndex == correspondingColumn.Index);
            if (targetCommand.CanExecute(null))
                targetCommand.Execute(null);
        }

        public IReadOnlyList<ICell> Cells
        {
            get { return _cells; }
        }

        public IReadOnlyCollection<IClickColumnCommand> ClickColumnCommands
        {
            get { return _clickColumnCommands; }
        }
    }
}