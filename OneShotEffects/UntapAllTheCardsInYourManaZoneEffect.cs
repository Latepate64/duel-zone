using Interfaces;

namespace OneShotEffects;

public sealed class UntapAllTheCardsInYourManaZoneEffect : OneShotEffect
{
    public UntapAllTheCardsInYourManaZoneEffect() : base()
    {
    }

    public UntapAllTheCardsInYourManaZoneEffect(
        UntapAllTheCardsInYourManaZoneEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        Controller.Untap(game, [.. Controller.ManaZone.Cards]);
    }

    public override IOneShotEffect Copy()
    {
        return new UntapAllTheCardsInYourManaZoneEffect(this);
    }
}
