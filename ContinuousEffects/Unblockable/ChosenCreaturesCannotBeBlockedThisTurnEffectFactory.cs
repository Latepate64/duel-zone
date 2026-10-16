using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Unblockable;

public class ChosenCreaturesCannotBeBlockedThisTurnEffectFactory
    : IContinuousEffectFactory
{
    public IContinuousEffect Create(IEnumerable<ICreature> creatures)
    {
        return new ChosenCreaturesCannotBeBlockedThisTurnEffect([.. creatures]);
    }
}