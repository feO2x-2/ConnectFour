using System;
using System.Collections.Generic;

namespace ConnectFour.Core
{
    public class Player : IPlayer
    {
        private readonly string _name;
        private readonly Color _color;
        private readonly IList<Chip> _chips;

        public Player(string name, Color color, IList<Chip> chips)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (color == null) throw new ArgumentNullException("color");
            if (chips == null) throw new ArgumentNullException("chips");

            _name = name;
            _color = color;
            _chips = chips;
        }

        public string Name
        {
            get { return _name; }
        }

        public Color Color
        {
            get { return _color; }
        }

        public IList<Chip> Chips
        {
            get { return _chips; }
        }

        public void PlaceChipInColumn(IColumn column)
        {
            if (column == null) throw new ArgumentNullException("column");
            if (Chips.Count == 0)
                throw new InvalidOperationException("Cannot place chip in column when player has no chips left.");

            var chip = Chips[0];
            Chips.RemoveAt(0);

            column.SetChip(chip);
        }
    }
}
