using Interfaces;

namespace Abilities;

public sealed class SpellAbility : ResolvableAbility, ISpellAbility
{
    public SpellAbility(IOneShotEffect effect) : base(effect)
    { }

    public SpellAbility(SpellAbility ability) : base(ability)
    { }

    public override IAbility Copy()
    {
        return new SpellAbility(this);
    }

    public override string ToString()
    {
        return UpperCaseFirstCharacter(OneShotEffect.ToString());
    }
}
