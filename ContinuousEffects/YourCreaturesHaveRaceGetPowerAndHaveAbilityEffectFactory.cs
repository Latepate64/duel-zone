using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class YourCreaturesHaveRaceGetPowerAndHaveAbilityEffectFactory
    : IYourCreaturesHaveRaceGetPowerAndHaveAbilityEffectFactory
{
    public IContinuousEffect Create(
        Race race,
        int power,
        IStaticAbilityFactory factory,
        params ICreature[] creatures)
    {
        return new YourCreaturesHaveRaceGetPowerAndHaveAbilityEffect(
            race,
            power,
            factory,
            [.. creatures]);
    }
}