using System;
using ConnectFour.Core;

namespace ConnectFour.WpfClient
{
    public class PlayerViewModel : BaseViewModel, IPlayerViewModel
    {
        private readonly IPlayer _player;
        private bool _hasTurn;

        public PlayerViewModel(IPlayer player)
        {
            if (player == null) throw new ArgumentNullException("player");
            _player = player;
        }

        public IPlayer Player
        {
            get { return _player; }
        }

        public bool HasTurn
        {
            get { return _hasTurn; }
            set { this.SetValueIfDifferent(value, ref _hasTurn); }
        }
    }
}