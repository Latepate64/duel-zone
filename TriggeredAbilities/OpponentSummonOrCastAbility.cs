using Interfaces;

namespace TriggeredAbilities;

public sealed class OpponentSummonOrCastAbility : TriggeredAbility
{
    public OpponentSummonOrCastAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public OpponentSummonOrCastAbility(OpponentSummonOrCastAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new OpponentSummonOrCastAbility(this);
    }

    public override string ToString()
    {
        return $"When your opponent summons a creature or casts a spell, {GetEffectText()}";
    }
}
