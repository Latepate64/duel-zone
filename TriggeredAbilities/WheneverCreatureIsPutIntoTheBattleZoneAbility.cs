using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public abstract class WheneverCreatureIsPutIntoTheBattleZoneAbility : CardChangesZoneAbility
{
    protected WheneverCreatureIsPutIntoTheBattleZoneAbility(WheneverCreatureIsPutIntoTheBattleZoneAbility ability)
        : base(ability)
    {
    }

    protected WheneverCreatureIsPutIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is ICardMovedEvent e && e.Destination == ZoneType.BattleZone
        && e.CardInDestinationZone is ICreature creature && TriggersFrom(creature, game);
    }
}
