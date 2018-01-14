using ConnectFour.Core;
using System.Collections.Generic;
using System.ComponentModel;

namespace ConnectFour.WpfClient.SampleData
{
    public class MainWindowViewModelSampleData : IMainWindowViewModel
    {
        private readonly IBoardViewModel _boardViewModel;
        private readonly IReadOnlyList<IPlayerViewModel> _playerViewModels;

        public MainWindowViewModelSampleData()
        {
            var spielerViewModels = new List<IPlayerViewModel>
                                    {
                                        new PlayerViewModelSampleData("Player A", new Color(128, 0, 0)),
                                        new PlayerViewModelSampleData("Player B", new Color(0, 0, 128))
                                        {
                                            HasTurn = false
                                        }
                                    };
            _playerViewModels = spielerViewModels;

            _boardViewModel = new BoardViewModelSampleData();
        }

        public IBoardViewModel BoardViewModel
        {
            get { return _boardViewModel; }
        }

        public IReadOnlyList<IPlayerViewModel> PlayerViewModels
        {
            get { return _playerViewModels; }
        }

        public string GameText
        {
            get { return "Player A wins!"; }
        }

        public void PlayTurn(IColumn column)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
