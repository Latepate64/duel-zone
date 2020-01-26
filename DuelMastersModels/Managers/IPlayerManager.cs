using DuelMastersModels.Cards;

namespace DuelMastersModels.Managers
{
    internal interface IPlayerManager
    {
        Player Player1 { get; }
        Player Player2 { get; }

        Player GetOpponent(IPlayer player);
        Player GetOwner(ICard card);
    }
}