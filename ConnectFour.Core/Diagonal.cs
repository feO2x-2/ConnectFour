using System;
using System.Collections.Generic;

namespace ConnectFour.Core
{
    public class Diagonal : BoardLine
    {
        public readonly int ColumnIndex;
        public readonly int RowIndex;
        public readonly DiagonalDirection Direction;

        public Diagonal(int columnIndex,
                        int rowIndex,
                        DiagonalDirection direction,
                        IReadOnlyList<ICell> cells) : base(cells)
        {
            if (columnIndex < 0) throw new ArgumentException("Column index cannot be less than zero.", "columnIndex");
            if (rowIndex < 0) throw new ArgumentException("Row index cannot be less than zero.", "rowIndex");
                
            ColumnIndex = columnIndex;
            RowIndex = rowIndex;
            Direction = direction;
        }
    }
}