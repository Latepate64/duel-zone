using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public class ForcedFrenzyContinuousEffectFactory
    : IContinuousEffectWithGameFactory
{
    public IContinuousEffect Create(IGame game, IPlayer player)
    {
        return new ForcedFrenzyContinuousEffect(game.GetOpponent(player));
    }
}