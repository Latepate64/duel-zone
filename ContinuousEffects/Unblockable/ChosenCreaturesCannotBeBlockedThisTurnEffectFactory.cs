using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Unblockable;

public class ChosenCreaturesCannotBeBlockedThisTurnEffectFactory
    : IContinuousEffectFactory
{
    public IContinuousEffect Create(params ICreature[] creatures)
    {
        return new ChosenCreaturesCannotBeBlockedThisTurnEffect(creatures);
    }
}