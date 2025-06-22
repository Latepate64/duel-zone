using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class UntapAllTheCardsInYourManaZoneEffect : UntapAreaOfEffect
{
    public UntapAllTheCardsInYourManaZoneEffect() : base()
    {
    }

    public UntapAllTheCardsInYourManaZoneEffect(UntapAreaOfEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new UntapAllTheCardsInYourManaZoneEffect(this);
    }

    public override string ToString()
    {
        return "Untap all the cards in your mana zone.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.Cards;
    }
}
