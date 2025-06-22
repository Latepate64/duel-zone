using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class DragonEvolutionEffect : SingleBaitEvolutionEffect
{
    public DragonEvolutionEffect() : base()
    {
    }

    public override bool CanEvolve(IGame game, ICreature evolutionCreature)
    {
        return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Any(bait => CanEvolveFrom(bait, evolutionCreature, game));
    }

    public bool CanEvolveFrom(ICreature bait, ICreature evolutionCard, IGame game)
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

    protected override IEnumerable<ICreature> GetPossibleBaits(IGame game, ICreature evolutionCreature)
    {
        return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Where(bait => CanEvolveFrom(bait, evolutionCreature, game));
    }
}
