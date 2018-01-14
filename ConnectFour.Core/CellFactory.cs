namespace ConnectFour.Core
{
    public class CellFactory : ICellFactory
    {
        public ICell Create(int columnIndex, int rowIndex)
        {
            return new Cell(columnIndex, rowIndex);
        }
    }
}