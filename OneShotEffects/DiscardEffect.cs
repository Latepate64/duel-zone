using Interfaces;

namespace OneShotEffects;

public sealed class DiscardEffect : CardMovingChoiceEffect
{
    public DiscardEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        ICardFilter filter,
        SelectionRange selectionRange) : base(
            minimum,
            maximum,
            controllerChooses,
            filter,
            ZoneType.Hand,
            ZoneType.Graveyard,
            selectionRange)
    {
    }

    private DiscardEffect(DiscardEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DiscardEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        if (selectionRange == SelectionRange.OwnCreatures)
        {
            return Applier.Hand.Cards;
        }
        else
        {
            return Applier.Opponent.Hand.Cards;
        }
    }
}
