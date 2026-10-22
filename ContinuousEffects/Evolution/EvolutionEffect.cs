using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Evolution;

public sealed class EvolutionEffect : ContinuousEffect, IEvolutionEffect
{
    private readonly ICardFilter filter;

    public EvolutionEffect(ICardFilter filter) : base()
    {
        this.filter = filter;
    }

    private EvolutionEffect(EvolutionEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new EvolutionEffect(this);
    }

    public bool CanEvolve(IGame game, ICreature evolutionCreature)
    {
        if (!IsSourceOfAbility(evolutionCreature)) return false;
        return game.BattleZone.HasCreaturesControllerByPlayer(Applier, filter);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not EvolutionEffect effect) return false;
        if (!filter.Equals(effect.filter)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), filter);
    }
}
