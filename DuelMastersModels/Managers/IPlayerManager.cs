using DuelMastersModels.Cards;

namespace DuelMastersModels.Managers
{
    internal interface IPlayerManager
    {
        IPlayer Player1 { get; }
        IPlayer Player2 { get; }

        IPlayer GetOpponent(IPlayer player);
        IPlayer GetOwner(ICard card);
    }
}