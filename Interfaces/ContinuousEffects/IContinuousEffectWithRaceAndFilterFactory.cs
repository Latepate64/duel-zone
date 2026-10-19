namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithRaceAndFilterFactory
{
    IContinuousEffect Create(Race race, ICardFilter filter);
}
