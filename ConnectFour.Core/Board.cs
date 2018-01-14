using System;
using System.Collections.Generic;

namespace ConnectFour.Core
{
    public class Board : IBoard
    {
        private readonly IReadOnlyList<ICell> _cells;
        private readonly IReadOnlyList<BoardLine> _boardLines;
        private readonly IReadOnlyList<Column> _columns;
        private readonly IReadOnlyList<Row> _rows;
        private readonly IReadOnlyList<Diagonal> _diagonals;

        public Board(IReadOnlyList<ICell> cells,
                     IReadOnlyList<BoardLine> boardLines,
                     IReadOnlyList<Column> columns,
                     IReadOnlyList<Row> rows,
                     IReadOnlyList<Diagonal> diagonals)
        {
            if (cells == null) throw new ArgumentNullException("cells");
            if (boardLines == null) throw new ArgumentNullException("boardLines");
            if (columns == null) throw new ArgumentNullException("columns");
            if (rows == null) throw new ArgumentNullException("rows");
            if (diagonals == null) throw new ArgumentNullException("diagonals");

            _cells = cells;
            _boardLines = boardLines;
            _columns = columns;
            _rows = rows;
            _diagonals = diagonals;
        }

        public IReadOnlyList<ICell> Cells
        {
            get { return _cells; }
        }

        public IReadOnlyList<Column> Columns
        {
            get { return _columns; }
        }

        public IReadOnlyList<Row> Rows
        {
            get { return _rows; }
        }

        public IReadOnlyList<Diagonal> Diagonals
        {
            get { return _diagonals; }
        }

        public string DetermineWinner()
        {
// ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var boardLine in _boardLines)
            {
                var winner = boardLine.DetermineIfPlayerHasFourInALine();
                if (winner != null)
                    return winner;
            }
            return null;
        }
    }
}
