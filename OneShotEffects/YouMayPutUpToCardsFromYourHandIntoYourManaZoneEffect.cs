using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Put up to maximum cards from your hand into your mana zone.
/// </summary>
public sealed class YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect
    : CardMovingChoiceEffect<ICard>
{
    private readonly ICardFilter filter;

    public YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(
        int minimum,
        int maximum,
        ICardFilter filter) : base(
            minimum, maximum, true, ZoneType.Hand, ZoneType.ManaZone)
    {
        this.filter = filter;
    }

    private YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(
        YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect effect) : base(
            effect)
    {
        filter = effect.filter.Copy();
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
