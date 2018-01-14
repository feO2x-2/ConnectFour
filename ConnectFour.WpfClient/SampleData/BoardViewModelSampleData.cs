using ConnectFour.Core;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFour.WpfClient.SampleData
{
    public class BoardViewModelSampleData : IBoardViewModel
    {
        private readonly IReadOnlyList<ICell> _cells;
        private readonly IReadOnlyCollection<IClickColumnCommand> _clickColumnCommands;

        public BoardViewModelSampleData()
        {
            // Plätze initialisieren
            var plätze = new Cell[7][];

            for (var i = 0; i < 7; i++)
            {
                plätze[i] = new Cell[6];
                for (var j = 0; j < 6; j++)
                {
                    plätze[i][j] = new Cell(i, j);
                }
            }

            for (var i = 0; i < 7; i++)
            {
                plätze[i][4].Chip = new Chip("Foo", new Color(128, 0, 0));
            }

            for (var i = 0; i < 7; i++)
            {
                plätze[i][5].Chip = new Chip("Bar", new Color(0, 0, 128));
            }

            _cells = plätze.SelectMany(innererArray => innererArray)
                            .ToList();

            // Spaltenkommandos initialisieren
            var klickSpalteKommandos = new List<IClickColumnCommand>();
            for (var i = 0; i < 7; i++)
            {
                var canExecute = i != 0 && i != 1;
                klickSpalteKommandos.Add(new ClickColumnCommandDummy(i, canExecute));
            }
            _clickColumnCommands = klickSpalteKommandos;
        }

        public IReadOnlyList<ICell> Cells
        {
            get { return _cells; }
        }

        public IReadOnlyCollection<IClickColumnCommand> ClickColumnCommands
        {
            get { return _clickColumnCommands; }
        }
    }
}
