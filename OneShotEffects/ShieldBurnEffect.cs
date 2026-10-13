using Interfaces;

namespace OneShotEffects;

public sealed class ShieldBurnEffect : CardMovingChoiceEffect
{
    public ShieldBurnEffect(
        int minimum,
        int maximum,
        ICardFilter filter,
        SelectionRange selectionRange) : base(
            minimum,
            maximum,
            controllerChooses: true,
            filter,
            ZoneType.ShieldZone,
            ZoneType.Graveyard,
            selectionRange)
    {
    }

    private ShieldBurnEffect(ShieldBurnEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ShieldBurnEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        if (selectionRange == SelectionRange.OwnCreatures)
        {
            return Applier.ShieldZone.Cards;
        }
        else
        {
            return Applier.Opponent.ShieldZone.Cards;
        }
    }
}
