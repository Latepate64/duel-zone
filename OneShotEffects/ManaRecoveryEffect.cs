using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Mana Recovery is a term given to cards that return cards in your mana zone
/// to your hand.
/// </summary>
public sealed class ManaRecoveryEffect : CardMovingChoiceEffect<ICard>
{
    private readonly bool ownMana;

    public ManaRecoveryEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        ICardFilter filter,
        bool ownMana) : base(
            minimum,
            maximum,
            controllerChooses,
            filter,
            ZoneType.ManaZone,
            ZoneType.Hand)
    {
        this.ownMana = ownMana;
    }

    private ManaRecoveryEffect(ManaRecoveryEffect effect) : base(effect)
    {
        ownMana = effect.ownMana;
    }

    public override IOneShotEffect Copy()
    {
        return new ManaRecoveryEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        if (ownMana)
        {
            return Applier.ManaZone.GetCards(filter);
        }
        else
        {
            return Applier.Opponent.ManaZone.GetCards(filter);
        }
    }
}
