namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithAbilityFactory
{
    IContinuousEffect Create(IAbility ability, params ICreature[] creatures);
}
