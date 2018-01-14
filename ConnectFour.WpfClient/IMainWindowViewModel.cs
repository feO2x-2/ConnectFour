using ConnectFour.Core;
using System.Collections.Generic;
using System.ComponentModel;

namespace ConnectFour.WpfClient
{
    public interface IMainWindowViewModel : INotifyPropertyChanged
    {
        IBoardViewModel BoardViewModel { get; }
        IReadOnlyList<IPlayerViewModel> PlayerViewModels { get; }
        string GameText { get; }
        void PlayTurn(IColumn column);
    }
}
