using Interfaces;

namespace TriggeredAbilities;

public sealed class WhenThisCreatureWinsBattleAbility : CardTriggeredAbility
{
    public WhenThisCreatureWinsBattleAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WhenThisCreatureWinsBattleAbility(WhenThisCreatureWinsBattleAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new WhenThisCreatureWinsBattleAbility(this);
    }

    public override string ToString()
    {
        return $"When this creature wins a battle, {GetEffectText()}";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card == Source;
    }
}
