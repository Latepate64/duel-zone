using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IAbilityAddingContinuousEffectFactory
{
    IContinuousEffect Create(
        IAbility ability, IEnumerable<ICreature> creatures);
}
