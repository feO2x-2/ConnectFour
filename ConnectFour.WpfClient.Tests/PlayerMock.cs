using System;
using System.Collections.Generic;
using ConnectFour.Core;

namespace ConnectFour.WpfClient.Tests
{
    public class PlayerMock : IPlayer
    {
        public void PlaceChipInColumn(IColumn column)
        {
            NumberOfPlaceChipInColumnCalls++;
        }

        public int NumberOfPlaceChipInColumnCalls { get; private set; }

        public bool WasPlaceChipInColumnCalledExactlyOnce
        {
            get { return NumberOfPlaceChipInColumnCalls == 1; }
        }

        public string Name
        {
            get { throw new NotSupportedException(); }
        }

        public Color Color
        {
            get { throw new NotSupportedException(); }
        }

        public IList<Chip> Chips
        {
            get { throw new NotSupportedException(); }
        }
    }
}