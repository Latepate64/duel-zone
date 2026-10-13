using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Put up to maximum cards from your hand into your mana zone.
/// </summary>
public sealed class YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect
    : CardMovingChoiceEffect<ICard>
{
    public YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(
        int minimum,
        int maximum,
        ICardFilter filter) : base(
            minimum, maximum, true, filter, ZoneType.Hand, ZoneType.ManaZone)
    {
    }

    private YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(
        YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect effect) : base(
            effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        return Controller.Hand.Cards;
    }
}
