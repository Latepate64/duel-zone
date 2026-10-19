namespace Interfaces.ContinuousEffects;

public interface IThisCreatureGetsTwoAbilitiesEffectFactory
{
    IContinuousEffect Create(
        int power,
        IStaticAbilityWithIntegerFactory abilityWithIntegerFactory, 
        IStaticAbilityFactory abilityFactory,
        params ICreature[] creatures);
}