using ConnectFour.Core;

namespace ConnectFour.WpfClient
{
    public interface IPlayerViewModel
    {
        IPlayer Player { get; }
        bool HasTurn { get; set; }
    }
}