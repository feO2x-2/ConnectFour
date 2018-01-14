using System;
using System.Collections.Generic;

namespace ConnectFour.Core
{
    public class Row : BoardLine
    {
        private readonly int _index;

        public Row(int index, IReadOnlyList<ICell> cells) : base(cells)
        {
            if (index < 0)
                throw new ArgumentException("Index cannot be less than zero", "index");
            _index = index;
        }
    }
}