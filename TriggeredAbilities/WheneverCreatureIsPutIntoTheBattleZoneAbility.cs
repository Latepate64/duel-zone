using Interfaces;

namespace TriggeredAbilities;

public abstract class WheneverCreatureIsPutIntoTheBattleZoneAbility
    : CardChangesZoneAbility
{
    protected WheneverCreatureIsPutIntoTheBattleZoneAbility(
        WheneverCreatureIsPutIntoTheBattleZoneAbility ability)
        : base(ability)
    {
    }

    protected WheneverCreatureIsPutIntoTheBattleZoneAbility(
        IOneShotEffect effect) : base(effect)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        if (gameEvent is not ICardMovedEvent e) return false;
        if (e.Destination != ZoneType.BattleZone) return false;
        if (e.CardInDestinationZone is not ICreature creature ) return false;
        if (!TriggersFrom(creature, game)) return false;
        return true;
    }
}
