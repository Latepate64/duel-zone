using Interfaces;

namespace OneShotEffects;

public sealed class ManaBurnEffect : CardMovingChoiceEffect
{
    public ManaBurnEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        ICardFilter filter,
        SelectionRange selectionRange) : base(
            minimum,
            maximum,
            controllerChooses,
            filter,
            ZoneType.ManaZone,
            ZoneType.Graveyard,
            selectionRange)
    {
    }

    private ManaBurnEffect(ManaBurnEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ManaBurnEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        if (selectionRange == SelectionRange.OwnCreatures)
        {
            return Applier.ManaZone.GetCards(filter);
        }
        else
        {
            return Applier.Opponent.ManaZone.GetCards(filter);
        }
    }
}
