using Engine.Abilities;

namespace Cards.OneShotEffects;

public class ThisCreatureBreaksOpponentsTwoShieldsEffect : ThisCreatureBreaksOpponentsShieldsEffect
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
