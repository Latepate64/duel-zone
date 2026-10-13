using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Mana Recovery is a term given to cards that return cards in your mana zone
/// to your hand.
/// </summary>
public sealed class ManaRecoveryEffect : CardMovingChoiceEffect
{
    public ManaRecoveryEffect(
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
            ZoneType.Hand,
            selectionRange)
    {
    }

    private ManaRecoveryEffect(ManaRecoveryEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ManaRecoveryEffect(this);
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
