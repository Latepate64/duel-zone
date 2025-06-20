using Engine.Abilities;

namespace OneShotEffects;

public class YouMayDrawUpToThreeCardsEffect : YouMayDrawCardsEffect
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
