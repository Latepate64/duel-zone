namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithTwoFiltersFactory
{
    IContinuousEffect Create(ICardFilter race, ICardFilter filter);
}
