using CardFilters;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Survivor (Each of your Survivors has this creature's Survivor ability.)
/// </summary>
public sealed class SurvivorEffect : EachOfYourCreaturesHasAbility
{
    public SurvivorEffect(IAbility ability) : base(
        ability, new RaceCreatureFilter(Race.Survivor))
    {
    }

    public SurvivorEffect(SurvivorEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new SurvivorEffect(this);
    }
}