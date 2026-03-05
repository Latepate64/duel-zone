using Interfaces;

namespace OneShotEffects;

public sealed class ThisCreatureBreaksOpponentsShieldEffect : ThisCreatureBreaksOpponentsShieldsEffect
{
    public ThisCreatureBreaksOpponentsShieldEffect(ThisCreatureBreaksOpponentsShieldsEffect effect) : base(effect)
    {
    }

    public ThisCreatureBreaksOpponentsShieldEffect() : base(1)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ThisCreatureBreaksOpponentsShieldEffect(this);
    }
}
