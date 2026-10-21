using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Evolution;

public sealed class YouCanPutEvolutionCreatureOfAnyRaceOnThisCreatureEffect
    : ContinuousEffect, IEvolutionEffect
{
    public bool CanEvolve(IGame game, ICreature evolutionCreature)
    {
        return evolutionCreature.OwnerV2.Equals(Applier);
    }

    public override IContinuousEffect Copy()
    {
        return new YouCanPutEvolutionCreatureOfAnyRaceOnThisCreatureEffect();
    }
}