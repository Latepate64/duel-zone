using Interfaces;

namespace OneShotEffects;

public sealed class YouMayDrawCardsEffect : OneShotEffect
{
    private readonly int maximum;

    public YouMayDrawCardsEffect(int maximum) : base()
    {
        this.maximum = maximum;
    }

    private YouMayDrawCardsEffect(YouMayDrawCardsEffect effect) : base(effect)
    {
        maximum = effect.maximum;
    }

    public override void Apply(IGame game)
    {
        Controller.DrawCardsOptionally(game, Ability, maximum);
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayDrawCardsEffect(this);
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not YouMayDrawCardsEffect effect) return false;
        if (maximum != effect.maximum) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), maximum);
    }
}
