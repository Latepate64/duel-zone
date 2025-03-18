using Engine.Abilities;
using System;

namespace Engine;

/// <summary>
/// 609.1.
/// An effect is something that happens in the game as a result of a spell or
/// ability.
/// </summary>
public abstract class Effect : IEffect
{
    protected Effect()
    {
    }

    protected Effect(IEffect effect)
    {
        Ability = effect.Ability;
    }

    /// <summary>
    /// 609.1. The ability that generated this effect.
    /// </summary>
    public IAbility Ability { get; set; }
    public IPlayer Controller => Ability.Controller;

    /// <summary>
    /// 113.7. 609.1.
    /// The card that generated the ability that generated this effect.
    /// </summary>
    public ICard Source => Ability.Source;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }

    public override abstract string ToString();

    protected bool IsSourceOfAbility(ICard card)
    {
        return card == Source;
    }

    protected IPlayer GetOpponent(IGame game)
    {
        return game.GetOpponent(Controller);
    }

    public override bool Equals(object obj)
    {
        return obj is Effect effect
            && ((Ability == null && effect.Ability == null)
            || (Ability != null && Ability.Equals(
                effect.Ability)));
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Ability);
    }
}