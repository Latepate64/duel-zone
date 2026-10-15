using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IContinuousEffectFactory
{
    IContinuousEffect Create(
        IAbility ability, IEnumerable<ICreature> creatures);
}