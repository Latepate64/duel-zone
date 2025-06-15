using System.Collections.Generic;

namespace Engine.GameEvents;

public class PutIntoGraveyardEvent(PlayerV2 player, Card card) : GameEventV2(player, false)
{
    public Card Card { get; } = card;

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is PutIntoGraveyardEvent e
            && Card == e.Card;
    }

    internal override IEnumerable<GameEventV2> Happen(GameState state)
    {
        Player.Graveyard.Add(Card);
        return [];
    }
}