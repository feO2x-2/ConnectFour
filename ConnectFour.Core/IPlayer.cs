using System.Collections.Generic;

namespace ConnectFour.Core
{
    public interface IPlayer
    {
        void PlaceChipInColumn(IColumn column);
        string Name { get; }
        Color Color { get; }
        IList<Chip> Chips { get; }
    }
}