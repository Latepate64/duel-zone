using Effects.Continuous;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Collections.Generic;

namespace Cards.ContinuousEffects;

public abstract class SingleBaitEvolutionEffect : ContinuousEffect, IEvolutionEffect
{
    protected SingleBaitEvolutionEffect()
    {
    }

    protected SingleBaitEvolutionEffect(SingleBaitEvolutionEffect effect) : base(effect)
    {
    }

    public abstract bool CanEvolve(IGame game, Creature evolutionCreature);

    public void Evolve(Creature evolutionCreature, IGame game)
    {
        var baits = GetPossibleBaits(game, evolutionCreature);
        var bait = evolutionCreature.Owner.ChooseCard(baits, "Choose a creature to evolve from.");
        game.ProcessEvents(new EvolutionEvent(evolutionCreature.Owner, evolutionCreature, bait));
    }

    protected abstract IEnumerable<Creature> GetPossibleBaits(IGame game, Creature evolutionCreature);
}
