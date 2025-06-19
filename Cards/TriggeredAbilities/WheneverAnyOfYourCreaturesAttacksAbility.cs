using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities;

public class WheneverAnyOfYourCreaturesAttacksAbility : WheneverCreatureAttacksAbility
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

    protected override bool TriggersFrom(Creature card, IGame game)
    {
        return card.Owner == Controller;
    }
}
