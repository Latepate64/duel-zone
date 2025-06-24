using Interfaces;

namespace GameEvents;

public sealed class PutIntoGraveyardEvent(IPlayerV2 player, ICard card) : GameEventV2(player, false)
{
    public ICard ICard { get; } = card;

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is PutIntoGraveyardEvent e
            && ICard == e.ICard;
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        Player.Graveyard.Add(ICard);
        return [];
    }
}