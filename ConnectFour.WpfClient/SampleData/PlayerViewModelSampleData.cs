using ConnectFour.Core;
using System.Collections.Generic;

namespace ConnectFour.WpfClient.SampleData
{
    public class PlayerViewModelSampleData : IPlayerViewModel
    {
        private readonly IPlayer _player;

        public PlayerViewModelSampleData()
            : this("Player B", new Color(0, 0, 128))
        {
            
        }

        public PlayerViewModelSampleData(string playerName, Color playerColor)
        {
            var chips = new List<Chip>();
            for (var i = 0; i < 21; i++)
            {
                chips.Add(new Chip(playerName, playerColor));
            }

            _player = new Player(playerName, playerColor, chips);
        }

        public IPlayer Player
        {
            get { return _player; }
        }

        public bool HasTurn { get; set; }
    }
}
