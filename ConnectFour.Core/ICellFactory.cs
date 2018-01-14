namespace ConnectFour.Core
{
    public interface ICellFactory
    {
        ICell Create(int columnIndex, int rowIndex);
    }
}