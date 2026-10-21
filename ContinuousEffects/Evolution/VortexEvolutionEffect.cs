using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Evolution;

public sealed class VortexEvolutionEffect : ContinuousEffect, IEvolutionEffect
{
    public VortexEvolutionEffect(Race race1, Race race2)
    {
        Race1 = race1;
        Race2 = race2;
    }

    public VortexEvolutionEffect(VortexEvolutionEffect effect) : base(effect)
    {
        Race1 = effect.Race1;
        Race2 = effect.Race2;
    }

    public Race Race1 { get; }
    public Race Race2 { get; }

    public bool CanEvolve(IGame game, ICreature evolutionCreature)
    {
        throw new NotImplementedException();
        // var baits = game.BattleZone.GetCreatures(evolutionCreature.Owner.Id);
        // var combinations = new Combinations<ICreature>(baits, 2, GenerateOption.WithoutRepetition);
        // var validPairs = combinations.Where(x => CanEvolveFrom(evolutionCreature, x[0], x[x.Count - 1]));
        // return validPairs.Any();
    }

    public override IContinuousEffect Copy()
    {
        return new VortexEvolutionEffect(this);
    }
}
