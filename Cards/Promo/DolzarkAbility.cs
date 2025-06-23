using TriggeredAbilities;
using Engine.Abilities;
using Interfaces;

namespace Cards.Promo;

public sealed class DolzarkAbility : WheneverCreatureAttacksAbility
{
    public DolzarkAbility(IOneShotEffect effect) : base(effect)
    {
    }

    DolzarkAbility(DolzarkAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new DolzarkAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever one of your other creatures that has Dragon in its race attacks, {GetEffectText()}";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card.Owner == Controller && card != Source && card.IsDragon;
    }
}
