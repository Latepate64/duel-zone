using Interfaces.ContinuousEffects;

namespace Interfaces;

public interface IContinuousEffectWithGameFactory
{
    IContinuousEffect Create(IGame game, IPlayer player);
}