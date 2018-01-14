using System;
using System.Collections.Generic;

namespace ConnectFour.Core
{
    public abstract class BoardLine
    {
        public readonly IReadOnlyList<ICell> Cells;

        protected BoardLine(IReadOnlyList<ICell> cells)
        {
            if (cells == null) throw new ArgumentNullException("cells");

            Cells = cells;
        }
        public string DetermineIfPlayerHasFourInALine()
        {
            var chipCounter = 0;
            string playerName = null;
            foreach (var cell in Cells)
            {
                var chip = cell.Chip;
                if (chip == null)
                {
                    playerName = null;
                    chipCounter = 0;
                    continue;
                }

                if (playerName != chip.PlayerName)
                {
                    playerName = chip.PlayerName;
                    chipCounter = 1;
                    continue;
                }

                chipCounter++;
                if (chipCounter >= 4)
                    return playerName;
            }

            return null;
        }
    }


}
