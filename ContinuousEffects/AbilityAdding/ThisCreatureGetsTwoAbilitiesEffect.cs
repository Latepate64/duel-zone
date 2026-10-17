using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureGetsTwoAbilitiesEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public ThisCreatureGetsTwoAbilitiesEffect(
        ICard card,
        int power,
        IStaticAbilityWithIntegerFactory abilityWithIntegerFactory, 
        IStaticAbilityFactory abilityFactory) : base(
            card,
            abilityWithIntegerFactory.Create(power),
            abilityFactory.Create())
    {
    }

    private ThisCreatureGetsTwoAbilitiesEffect(
        ThisCreatureGetsTwoAbilitiesEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsTwoAbilitiesEffect(this);
    }
}
