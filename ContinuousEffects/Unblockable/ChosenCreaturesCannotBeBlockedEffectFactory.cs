using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Unblockable;

public class ChosenCreaturesCannotBeBlockedEffectFactory : IContinuousEffectFactory
{
    public IContinuousEffect Create(params ICreature[] creatures)
    {
        return new ChosenCreaturesCannotBeBlockedEffect(creatures);
    }
}