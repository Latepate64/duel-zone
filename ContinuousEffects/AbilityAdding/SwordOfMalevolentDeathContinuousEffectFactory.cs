using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class SwordOfMalevolentDeathContinuousEffectFactory
    : IContinuousEffectWithCreaturesAndIntegerFactory
{
    public IContinuousEffect Create(int integer, params ICreature[] creatures)
    {
        return new SwordOfMalevolentDeathContinuousEffect(integer, creatures);
    }
}