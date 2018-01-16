using System;
using System.Collections.Generic;
using System.Linq;
using ConnectFour.Core;

namespace ConnectFour.WpfClient
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private readonly IBoardViewModel _boardViewModel;
        private readonly IReadOnlyList<IPlayerViewModel> _playerViewModels;
        private readonly IBoard _board;
        private string _gameText;
        private readonly Action<string> _showWinnerDialog;

        public MainWindowViewModel(IReadOnlyList<IPlayerViewModel> playerViewModels, IBoardViewModel boardViewModel, IBoard board, Action<string> showWinnerDialog)
        {
            _playerViewModels = playerViewModels;
            _boardViewModel = boardViewModel;
            _board = board;
            _showWinnerDialog = showWinnerDialog;
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
            get { return _gameText; }
            private set { this.SetValueIfDifferent(value, ref _gameText); }
        }

        public void PlayTurn(IColumn column)
        {
            if (column == null) throw new ArgumentNullException("column");

            var currentPlayerViewModel = _playerViewModels.First(vm => vm.HasTurn);
            currentPlayerViewModel.Player.PlaceChipInColumn(column);

            var winnerName = _board.DetermineWinner();
            if (winnerName != null)
            {
                GameText = winnerName + " wins!";
                _showWinnerDialog(winnerName);
            }
            else
            {
                foreach (var playerViewModel in _playerViewModels)
                    playerViewModel.HasTurn = !playerViewModel.HasTurn;
            }
        }
    }
}