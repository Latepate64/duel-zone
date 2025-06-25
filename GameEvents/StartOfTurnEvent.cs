using Interfaces;

namespace GameEvents;

public sealed class StartOfTurnEvent : GameEventV2
{
    public StartOfTurnEvent(IPlayerV2 player) : base(player, false)
    {
    }

    StartOfTurnEvent(IGameEventV2 gameEvent) : base(gameEvent)
    {
    }

    public override IGameEventV2 Copy()
    {
        return new StartOfTurnEvent(this);
    }

    public override IEnumerable<IGameEventV2> Happen(IGameState state)
    {
        // 1.1) Remove any summoning sickness from your creatures in the battle zone.
        // 1.2) You must untap each of your cards in the battle zone and your mana zone.
        // 1.3) Any abilities that trigger "At the start of your turn" or "At the start of your opponent's turn" are resolved now.
        return [];
    }
}