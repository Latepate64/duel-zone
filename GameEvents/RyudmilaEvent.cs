using Engine.GameEvents;
using Interfaces;

namespace GameEvents;

public sealed class RyudmilaEvent(ICard card) : GameEvent
{
    private readonly ICard _card = card;

    public override void Happen(IGame game)
    {
        game.Move(null, ZoneType.BattleZone, ZoneType.Deck, _card);
        _card.Owner.ShuffleOwnDeck(game);
    }

    public override string ToString()
    {
        return "Shuffle it into your deck instead.";
    }
}
