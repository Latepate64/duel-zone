using Engine.Abilities;

namespace OneShotEffects;

public sealed class ThisCreatureBreaksOpponentsTwoShieldsEffect : ThisCreatureBreaksOpponentsShieldsEffect
{
    public ThisCreatureBreaksOpponentsTwoShieldsEffect(ThisCreatureBreaksOpponentsShieldsEffect effect) : base(effect)
    {
    }

    public ThisCreatureBreaksOpponentsTwoShieldsEffect() : base(2)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ThisCreatureBreaksOpponentsTwoShieldsEffect(this);
    }
}
