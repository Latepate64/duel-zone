namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithStaticAbilityFactoryFactory
{
    IContinuousEffect Create(IStaticAbilityFactory factory, params ICreature[] creatures);
}
