using Engine.Abilities;

namespace OneShotEffects;

public class OpponentDiscardsCardAtRandomEffect : OpponentRandomDiscardEffect
{
    public OpponentDiscardsCardAtRandomEffect() : base(1)
    {
    }

    public OpponentDiscardsCardAtRandomEffect(OpponentRandomDiscardEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new OpponentDiscardsCardAtRandomEffect(this);
    }
}
