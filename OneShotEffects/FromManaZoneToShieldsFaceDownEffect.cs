using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Add a card from your mana zone to your shields face down.
/// </summary>
public sealed class FromManaZoneToShieldsFaceDownEffect
    : CardMovingChoiceEffect<ICard>
{
    private readonly ICardFilter filter;

    public FromManaZoneToShieldsFaceDownEffect(ICardFilter filter) : base(
        1, 1, true, ZoneType.ManaZone, ZoneType.ShieldZone)
    {
        this.filter = filter;
    }

    public FromManaZoneToShieldsFaceDownEffect(
        FromManaZoneToShieldsFaceDownEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
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
