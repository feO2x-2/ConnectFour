using System;

namespace ConnectFour.Core
{
    public class Chip
    {
        private readonly string _playerName;
        private readonly Color _color;

        public Chip(string playerName, Color color)
        {
            if (playerName == null) throw new ArgumentNullException("playerName");
            if (color == null) throw new ArgumentNullException("color");

            _playerName = playerName;
            _color = color;
        }

        public string PlayerName
        {
            get { return _playerName; }
        }

        public Color Color
        {
            get { return _color; }
        }
    }
}
