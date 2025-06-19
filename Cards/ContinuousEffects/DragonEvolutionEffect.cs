using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.ContinuousEffects;

public class DragonEvolutionEffect : SingleBaitEvolutionEffect
{
    public DragonEvolutionEffect() : base()
    {
    }

    public override bool CanEvolve(IGame game, Creature evolutionCreature)
    {
        return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Any(bait => CanEvolveFrom(bait, evolutionCreature, game));
    }

    public bool CanEvolveFrom(Creature bait, Creature evolutionCard, IGame game)
    {
        return bait.IsDragon && IsSourceOfAbility(evolutionCard);
    }

    public override IContinuousEffect Copy()
    {
        return new DragonEvolutionEffect();
    }

    public override string ToString()
    {
        return $"Evolution - Put on one of your creatures that has Dragon in its race.";
    }

    protected override IEnumerable<Creature> GetPossibleBaits(IGame game, Creature evolutionCreature)
    {
        return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Where(bait => CanEvolveFrom(bait, evolutionCreature, game));
    }
}
