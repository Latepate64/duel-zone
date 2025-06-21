using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public abstract class DestroyedAbility : CardChangesZoneAbility
{
    protected DestroyedAbility(IOneShotEffect effect) : base(effect)
    {
    }

    protected DestroyedAbility(DestroyedAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is CardMovedEvent e && e.Source == ZoneType.BattleZone
        && e.Destination == ZoneType.Graveyard && e.CardInDestinationZone is Creature creature
        && TriggersFrom(creature, game);
    }
}
