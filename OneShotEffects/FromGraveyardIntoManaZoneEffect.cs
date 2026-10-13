using Interfaces;

namespace OneShotEffects;

public sealed class FromGraveyardIntoManaZoneEffect
    : CardMovingChoiceEffect<ICard>
{
    public FromGraveyardIntoManaZoneEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        ICardFilter filter) : base(
            minimum,
            maximum,
            controllerChooses,
            filter,
            ZoneType.Graveyard,
            ZoneType.ManaZone)
    {
    }

    private FromGraveyardIntoManaZoneEffect(
        FromGraveyardIntoManaZoneEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new FromGraveyardIntoManaZoneEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        return Controller.Graveyard.GetCards(filter);
    }
}
