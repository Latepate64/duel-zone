namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithAbilityFactory
{
    IContinuousEffect Create(IStaticAbilityFactory factory, params ICreature[] creatures);
}
