namespace Interfaces.ContinuousEffects;

public interface IContinuousEffectWithGameFactory
{
    IContinuousEffect Create(IGame game, IPlayer player);
}