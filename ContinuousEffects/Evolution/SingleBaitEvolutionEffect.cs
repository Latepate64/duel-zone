using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Evolution;

public abstract class SingleBaitEvolutionEffect : ContinuousEffect, IEvolutionEffect
{
    protected SingleBaitEvolutionEffect()
    {
    }

    protected SingleBaitEvolutionEffect(SingleBaitEvolutionEffect effect) : base(effect)
    {
    }

    public abstract bool CanEvolve(IGame game, ICreature evolutionCreature);

    public void Evolve(ICreature evolutionCreature, IGame game)
    {
        var baits = GetPossibleBaits(game, evolutionCreature);
        var bait = evolutionCreature.Owner.ChooseCard(baits, "Choose a creature to evolve from.");
        throw new NotImplementedException();
    }

    protected abstract IEnumerable<ICreature> GetPossibleBaits(IGame game, ICreature evolutionCreature);
}
