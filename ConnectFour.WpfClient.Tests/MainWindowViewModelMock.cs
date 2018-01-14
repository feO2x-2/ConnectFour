using System;
using System.Collections.Generic;
using System.ComponentModel;
using ConnectFour.Core;

namespace ConnectFour.WpfClient.Tests
{
    public class MainWindowViewModelMock : IMainWindowViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IBoardViewModel BoardViewModel
        {
            get { throw new NotSupportedException(); }
        }

        public IReadOnlyList<IPlayerViewModel> PlayerViewModels
        {
            get { throw new NotSupportedException(); }
        }

        public string GameText { get; private set; }

        public void PlayTurn(IColumn column)
        {
            PlayTurnCallCount++;
        }

        public int PlayTurnCallCount { get; private set; }

        public bool WasPlayTurnCalledExactlyOnce
        {
            get { return PlayTurnCallCount == 1; }
        }

        public void SetWinnerName(string name)
        {
            GameText = name;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("GameText"));
        }
    }
}