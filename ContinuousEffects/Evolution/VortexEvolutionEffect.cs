using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Evolution;

public sealed class VortexEvolutionEffect : ContinuousEffect, IEvolutionEffect
{
    private readonly ICardFilter[] filters;

    public VortexEvolutionEffect(ICardFilter filter1, ICardFilter filter2)
    {
        filters = [filter1, filter2];
    }

    private VortexEvolutionEffect(VortexEvolutionEffect effect) : base(effect)
    {
        filters = [.. effect.filters.Select(x => x.Copy())];
    }

    public override IContinuousEffect Copy()
    {
        return new VortexEvolutionEffect(this);
    }

    public bool CanEvolve(IGame game, ICreature evolutionCreature)
    {
        if (!IsSourceOfAbility(evolutionCreature)) return false;
        var creaturesByFilters = filters.Select(
            x => game.BattleZone.GetCreaturesControlledByPlayer(Applier, x));
        for (var i = 0; i < creaturesByFilters.Count(); ++i)
        {
            var creatures1 = creaturesByFilters.ElementAt(i);
            for (var j = i+1; j < creaturesByFilters.Count(); ++j)
            {
                var creatures2 = creaturesByFilters.ElementAt(j);
                if (creatures1.Any(x => !creatures2.Contains(x))) return true;
            }
        }
        return false;
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not VortexEvolutionEffect effect) return false;
        if (!filters.SequenceEqual(effect.filters)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(base.GetHashCode());
        foreach (var filter in filters)
        {
            hash.Add(filter);
        }
        return hash.ToHashCode();
    }
}
