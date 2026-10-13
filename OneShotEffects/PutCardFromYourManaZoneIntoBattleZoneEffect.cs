using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Put a card from your mana zone into the battle zone.
/// </summary>
public sealed class PutCardFromYourManaZoneIntoBattleZoneEffect
    : CardMovingChoiceEffect
{
    public PutCardFromYourManaZoneIntoBattleZoneEffect(
        int minimum, ICardFilter filter)
        : base(minimum, 1, true, filter, ZoneType.ManaZone, ZoneType.BattleZone)
    {
    }

    public PutCardFromYourManaZoneIntoBattleZoneEffect(
        PutCardFromYourManaZoneIntoBattleZoneEffect effect) : base(effect)
    {
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
