using Interfaces;

namespace TriggeredAbilities;

public sealed class WhenThisCreatureBattlesAbility : CardTriggeredAbility
{
    public WhenThisCreatureBattlesAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WhenThisCreatureBattlesAbility(WhenThisCreatureBattlesAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new WhenThisCreatureBattlesAbility(this);
    }

    public override string ToString()
    {
        return $"When this creature battles, {GetEffectText()}";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card == Source;
    }
}
