using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public sealed class WheneverAnyOfYourCreaturesAttacksAbility : WheneverCreatureAttacksAbility
{
    public WheneverAnyOfYourCreaturesAttacksAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public WheneverAnyOfYourCreaturesAttacksAbility(WheneverAnyOfYourCreaturesAttacksAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new WheneverAnyOfYourCreaturesAttacksAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever any of your creatures attacks, {GetEffectText()}";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card.Owner == Controller;
    }
}
