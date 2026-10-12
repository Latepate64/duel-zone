using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Put a card from your mana zone into the battle zone.
/// </summary>
public sealed class PutCardFromYourManaZoneIntoBattleZoneEffect
    : CardMovingChoiceEffect<ICard>
{
    private readonly ICardFilter filter;

    public PutCardFromYourManaZoneIntoBattleZoneEffect(
        int minimum, ICardFilter filter)
        : base(minimum, 1, true, ZoneType.ManaZone, ZoneType.BattleZone)
    {
        this.filter = filter;
    }

    public PutCardFromYourManaZoneIntoBattleZoneEffect(
        PutCardFromYourManaZoneIntoBattleZoneEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new PutCardFromYourManaZoneIntoBattleZoneEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        return Controller.ManaZone.GetCards(filter);
    }
}
