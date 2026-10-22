namespace Interfaces.ContinuousEffects;

public interface IAbilityAddingContinuousEffectFactory
{
    IContinuousEffect Create(IAbility ability, params ICreature[] creatures);
}
