namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithAbilitiesAndCreaturesFactory
{
    IContinuousEffect Create(IAbility[] abilities, params ICreature[] creatures);
}
