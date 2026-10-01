using Interfaces;

namespace TriggeredAbilities;

public sealed class WhenThisCreatureAttacksPlayerAbility : WheneverThisCreatureAttacksAbility
{
    public WhenThisCreatureAttacksPlayerAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WhenThisCreatureAttacksPlayerAbility(WheneverThisCreatureAttacksAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IAbility Copy()
    {
        return new WhenThisCreatureAttacksPlayerAbility(this);
    }

    public override string ToString()
    {
        return $"When this creature attacks a player, {GetEffectText()}";
    }
}
