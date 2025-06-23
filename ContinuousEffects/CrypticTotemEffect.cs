using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class CrypticTotemEffect : ContinuousEffect, ICannotUseShieldTriggerEffect
{
    public CrypticTotemEffect()
    {
    }

    public CrypticTotemEffect(CrypticTotemEffect effect) : base(effect)
    {
    }

    public bool Applies(ICard shield, IGame game)
    {
        return Source.Tapped && game.GetOpponent(Controller).Id == shield.Id;
    }

    public override IContinuousEffect Copy()
    {
        return new CrypticTotemEffect(this);
    }

    public override string ToString()
    {
        return "While this creature is tapped, your opponent can't use the \"shield trigger\" ability of his shields.";
    }
}
