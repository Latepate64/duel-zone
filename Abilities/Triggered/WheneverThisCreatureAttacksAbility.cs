using Engine;
using Engine.Abilities;

namespace Abilities.Triggered;

public class WheneverThisCreatureAttacksAbility : WheneverCreatureAttacksAbility
{
    public WheneverThisCreatureAttacksAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WheneverThisCreatureAttacksAbility(WheneverThisCreatureAttacksAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new WheneverThisCreatureAttacksAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever this creature attacks, {GetEffectText()}";
    }

    protected override bool TriggersFrom(Creature card, IGame game)
    {
        return card == Source;
    }
}
