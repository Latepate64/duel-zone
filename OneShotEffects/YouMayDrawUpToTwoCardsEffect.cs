using Engine.Abilities;

namespace OneShotEffects;

public sealed class YouMayDrawUpToTwoCardsEffect : YouMayDrawCardsEffect
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
