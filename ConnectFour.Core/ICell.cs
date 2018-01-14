namespace ConnectFour.Core
{
    public interface ICell
    {
        Chip Chip { get; set; }
        int X { get; }
        int Y { get; }
    }
}