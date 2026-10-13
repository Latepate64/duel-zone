using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Add a card from your mana zone to your shields face down.
/// </summary>
public sealed class FromManaZoneToShieldsFaceDownEffect
    : CardMovingChoiceEffect<ICard>
{
    public FromManaZoneToShieldsFaceDownEffect(ICardFilter filter) : base(
        1, 1, true, filter, ZoneType.ManaZone, ZoneType.ShieldZone)
    {
    }

    public FromManaZoneToShieldsFaceDownEffect(
        FromManaZoneToShieldsFaceDownEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new FromManaZoneToShieldsFaceDownEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        return Controller.ManaZone.GetCards(filter);
    }
}
