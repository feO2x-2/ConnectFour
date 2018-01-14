using System.Collections.Generic;

namespace ConnectFour.Core.Tests
{
    public class ColumnFixture
    {
        private Color _color = new Color(128, 0, 0);
        private string _playerName = "Player A";
        private int _columnIndex;
        private List<Cell> _cells = new List<Cell>();

        public List<Cell> Cells
        {
            get { return _cells; }
        }

        public ColumnFixture WithNumberOfEmptyCells(int number)
        {
            for (var i = 0; i < number; i++)
            {
                Cells.Add(new Cell(_columnIndex, Cells.Count));
            }
            return this;
        }

        public ColumnFixture WithNumberOfCellsWithChip(int number)
        {
            for (var i = 0; i < number; i++)
            {
                Cells.Add(new Cell(_columnIndex, Cells.Count) { Chip = CreateChip() });
            }
            return this;
        }

        public Chip CreateChip()
        {
            return new Chip(_playerName, _color);
        }

        public Column CreateTestTarget()
        {
            return new Column(_columnIndex, _cells);
        }
    }
}