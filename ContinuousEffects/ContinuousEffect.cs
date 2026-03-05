using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// 611.1. A continuous effect modifies characteristics of objects, modifies control of objects, or affects players or the rules of the game, for a fixed or indefinite period.
/// </summary>
public abstract class ContinuousEffect : IContinuousEffect
{
    public int Timestamp { get; set; }
    public IAbility Ability { get; set; }
    public IPlayer Controller => Ability.Controller;
    public ICard Source => Ability.Source;

    protected ContinuousEffect()
    {
    }

    protected ContinuousEffect(IContinuousEffect effect)
    {
        Timestamp = effect.Timestamp;
        Ability = effect.Ability.Copy();
    }

    public abstract IContinuousEffect Copy();

    public override abstract string ToString();

    protected bool IsSourceOfAbility(ICard card)
    {
        return card == Source;
    }

    protected IPlayer GetOpponent(IGame game)
    {
        return game.GetOpponent(Controller);
    }
}