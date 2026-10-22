namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithAbilityIntegerAndCreaturesFactory
{
    IContinuousEffect Create(IAbility ability, int number, params ICreature[] creatures);
}