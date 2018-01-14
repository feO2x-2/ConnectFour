using ConnectFour.Core;
using System;
using System.Collections.Generic;

namespace ConnectFour.WpfClient.Tests
{
    public class BoardMock : IBoard
    {
        public IReadOnlyList<ICell> Cells
        {
            get { throw new NotSupportedException(); }
        }

        public IReadOnlyList<Column> Columns
        {
            get { throw new NotSupportedException(); }
        }

        public IReadOnlyList<Row> Rows
        {
            get { throw new NotSupportedException(); }
        }

        public IReadOnlyList<Diagonal> Diagonals
        {
            get { throw new NotSupportedException(); }
        }

        public string DetermineWinner()
        {
            NumberOfDetermineWinnerCalls++;
            return WinnerName;
        }

        public string WinnerName { get; set; }

        public int NumberOfDetermineWinnerCalls { get; private set; }

        public bool WasDetermineWinnerCalledExactlyOnce
        {
            get { return NumberOfDetermineWinnerCalls == 1; }
        }
    }
}