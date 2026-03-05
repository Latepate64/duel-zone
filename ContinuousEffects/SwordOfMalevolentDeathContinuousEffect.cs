using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class SwordOfMalevolentDeathContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public SwordOfMalevolentDeathContinuousEffect(SwordOfMalevolentDeathContinuousEffect effect) : base(effect)
    {
    }

    public SwordOfMalevolentDeathContinuousEffect(int power, params ICard[] cards) : base(
        new StaticAbility(new PowerAttackerEffect(power)), cards)
        {
        }

    public override IContinuousEffect Copy()
    {
        return new SwordOfMalevolentDeathContinuousEffect(this);
    }

    public override string ToString()
    {
        return "Until the end of the turn, this creature has \"While attacking, this creature gets +1000 power for each darkness card in your mana zone.\"";
    }
}
