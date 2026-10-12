using Interfaces;

namespace OneShotEffects;

/// <summary>
/// You may put a card from your hand into the battle zone.
/// </summary>
public sealed class YouMayPutCardFromYourHandIntoBattleZoneEffect
    : CardMovingChoiceEffect<ICard>
{
    private readonly ICardFilter filter;

    public YouMayPutCardFromYourHandIntoBattleZoneEffect(
        ICardFilter filter) : base(
            0, 1, true, ZoneType.Hand, ZoneType.BattleZone)
    {
        this.filter = filter;
    }

    public YouMayPutCardFromYourHandIntoBattleZoneEffect(
        YouMayPutCardFromYourHandIntoBattleZoneEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayPutCardFromYourHandIntoBattleZoneEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        return Controller.Hand.GetCards(filter);
    }
}
