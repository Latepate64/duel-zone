using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class MiraclePortalContinuousEffectFactory : IContinuousEffectFactory
{
    public IContinuousEffect Create(params ICreature[] creatures)
    {
        return new MiraclePortalContinuousEffect(creatures.Single());
    }
}