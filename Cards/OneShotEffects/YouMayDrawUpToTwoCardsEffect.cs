using Engine.Abilities;

namespace Cards.OneShotEffects;

public class YouMayDrawUpToTwoCardsEffect : YouMayDrawCardsEffect
{
    public YouMayDrawUpToTwoCardsEffect() : base(2)
    {
    }

    public YouMayDrawUpToTwoCardsEffect(YouMayDrawUpToTwoCardsEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayDrawUpToTwoCardsEffect(this);
    }
}
