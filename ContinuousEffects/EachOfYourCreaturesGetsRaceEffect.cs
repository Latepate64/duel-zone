using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class EachOfYourCreaturesGetsRaceEffect : ContinuousEffect, IRaceAddingEffect
{
    private readonly Race race;
    private readonly ICardFilter filter;

    public EachOfYourCreaturesGetsRaceEffect(Race race, ICardFilter filter)
    {
        this.race = race;
        this.filter = filter;
    }

    public EachOfYourCreaturesGetsRaceEffect(EachOfYourCreaturesGetsRaceEffect effect)
    {
        race = effect.race;
        filter = effect.filter.Copy();
    }

    public void AddRace(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
        foreach (var creature in creatures)
        {
            creature.AddGrantedRace(race);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new EachOfYourCreaturesGetsRaceEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not EachOfYourCreaturesGetsRaceEffect effect) return false;
        if (race != effect.race) return false;
        if (!filter.Equals(effect.filter)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), race, filter);
    }
}
