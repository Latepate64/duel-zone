using Engine.Abilities;

namespace Cards.OneShotEffects;

public class ThisCreatureBreaksOpponentsShieldEffect : ThisCreatureBreaksOpponentsShieldsEffect
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
