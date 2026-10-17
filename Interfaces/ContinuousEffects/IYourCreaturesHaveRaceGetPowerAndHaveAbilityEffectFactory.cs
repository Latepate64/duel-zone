namespace Interfaces.ContinuousEffects;

public interface IYourCreaturesHaveRaceGetPowerAndHaveAbilityEffectFactory
{
    IContinuousEffect Create(
        Race race,
        int power,
        IStaticAbilityFactory factory,
        params ICreature[] creatures);
}