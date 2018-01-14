using System.Collections.Generic;
using ConnectFour.Core;

namespace ConnectFour.WpfClient
{
    public interface IBoardViewModel
    {
        IReadOnlyList<ICell> Cells { get; }
        IReadOnlyCollection<IClickColumnCommand> ClickColumnCommands { get; }
    }
}