using System.Windows.Input;

namespace ConnectFour.WpfClient
{
    public interface IClickColumnCommand : ICommand
    {
        int ColumnIndex { get; }
    }
}