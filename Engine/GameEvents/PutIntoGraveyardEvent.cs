using System.Collections.Generic;

namespace Engine.GameEvents;

public class PutIntoGraveyardEvent(IPlayerV2 player, ICard card) : GameEventV2(player, false)
{
    public ICard ICard { get; } = card;

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is PutIntoGraveyardEvent e
            && ICard == e.ICard;
    }

    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        Player.Graveyard.Add(ICard);
        return [];
    }
}