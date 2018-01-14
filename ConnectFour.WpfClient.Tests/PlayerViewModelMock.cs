using ConnectFour.Core;

namespace ConnectFour.WpfClient.Tests
{
    public class PlayerViewModelMock : IPlayerViewModel
    {
        private readonly IPlayer _player;

        public PlayerViewModelMock(IPlayer player)
        {
            _player = player;
        }

        public IPlayer Player
        {
            get { return _player; }
        }

        public bool HasTurn { get; set; }
    }
}