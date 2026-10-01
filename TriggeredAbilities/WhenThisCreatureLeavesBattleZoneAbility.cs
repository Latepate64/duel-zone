using Interfaces;

namespace TriggeredAbilities;

public sealed class WhenThisCreatureLeavesBattleZoneAbility : TriggeredAbility
{
    public WhenThisCreatureLeavesBattleZoneAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WhenThisCreatureLeavesBattleZoneAbility(TriggeredAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new WhenThisCreatureLeavesBattleZoneAbility(this);
    }

    public override string ToString()
    {
        return $"When this creature leaves the battle Zone, {GetEffectText()}";
    }
}
