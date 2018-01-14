using System.Collections.Generic;

namespace ConnectFour.Core.Tests
{
    public class LineDummy : BoardLine
    {
        public LineDummy(IReadOnlyList<Cell> cells) : base(cells)
        {
        }
    }
}