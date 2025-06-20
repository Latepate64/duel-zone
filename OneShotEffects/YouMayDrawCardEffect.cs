using Engine.Abilities;

namespace OneShotEffects;

public class YouMayDrawCardEffect : YouMayDrawCardsEffect
{
    public YouMayDrawCardEffect() : base(1)
    {
    }

    public YouMayDrawCardEffect(YouMayDrawCardsEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayDrawCardEffect(this);
    }
}
