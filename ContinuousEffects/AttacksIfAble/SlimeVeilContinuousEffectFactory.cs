using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AttacksIfAble;

public class SlimeVeilContinuousEffectFactory
    : IContinuousEffectWithGameFactory
{
    public IContinuousEffect Create(IGame game, IPlayer player)
    {
        return new SlimeVeilContinuousEffect(game.GetOpponent(player));
    }
}