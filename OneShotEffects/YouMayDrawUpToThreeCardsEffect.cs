using Engine.Abilities;

namespace OneShotEffects;

public sealed class YouMayDrawUpToThreeCardsEffect : YouMayDrawCardsEffect
{
    public YouMayDrawUpToThreeCardsEffect() : base(3)
    {
    }

    public YouMayDrawUpToThreeCardsEffect(YouMayDrawUpToThreeCardsEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayDrawUpToThreeCardsEffect(this);
    }
}
