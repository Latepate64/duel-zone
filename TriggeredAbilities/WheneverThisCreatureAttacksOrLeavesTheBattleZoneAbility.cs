using Interfaces;

namespace TriggeredAbilities;

public sealed class WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility : TriggeredAbility
{
    public WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility(TriggeredAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever this creature attacks or leaves the battle zone, {GetEffectText()}";
    }
}
