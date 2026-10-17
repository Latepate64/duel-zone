using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CanAttackUntappedCreatures;

public class ThisCreatureCanAttackUntappedCreaturesEffectFactory
{
    public ICanAttackUntappedCreaturesEffect Create()
    {
        return new ThisCreatureCanAttackUntappedCreaturesEffect();
    }
}