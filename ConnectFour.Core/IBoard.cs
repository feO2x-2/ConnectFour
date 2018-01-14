using System.Collections.Generic;

namespace ConnectFour.Core
{
    public interface IBoard
    {
        IReadOnlyList<ICell> Cells { get; }
        IReadOnlyList<Column> Columns { get; }
        IReadOnlyList<Row> Rows { get; }
        IReadOnlyList<Diagonal> Diagonals { get; }
        string DetermineWinner();
    }
}