using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// 611.1. A continuous effect modifies characteristics of objects, modifies
/// control of objects, or affects players or the rules of the game, for a fixed
/// or indefinite period.
/// </summary>
public abstract class ContinuousEffect : IContinuousEffect
{
    public int Timestamp { get; set; }
    public IAbility? Ability { get; set; }
    public IPlayer? Controller => Ability?.Controller;
    public ICard? Source => Ability?.Source;
    public IPlayerV2 Applier { get; init; }

    protected ContinuousEffect()
    {
    }

    protected ContinuousEffect(IContinuousEffect effect)
    {
        Timestamp = effect.Timestamp;
        Ability = effect.Ability?.Copy();
    }

    public abstract IContinuousEffect Copy();

    protected bool IsSourceOfAbility(ICard card)
    {
        return card == Source;
    }

    protected IPlayer GetOpponent(IGame game)
    {
        return game.GetOpponent(Controller);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not ContinuousEffect effect) return false;
        if (!Timestamp.Equals(effect.Timestamp)) return false;
        if (Ability == null && effect.Ability != null) return false;
        if (Ability != null && !Ability.Equals(effect.Ability)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}