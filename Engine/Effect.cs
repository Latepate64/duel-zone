using Engine.Abilities;
using System;

namespace Engine;

public abstract class Effect : IEffect
{
    protected Effect()
    {
    }

    protected Effect(IEffect effect)
    {
        Ability = effect.Ability;
    }

    public IAbility Ability { get; set; }
    public IPlayer Controller => Ability.Controller;
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