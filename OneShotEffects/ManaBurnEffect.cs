using Interfaces;

namespace OneShotEffects;

public sealed class ManaBurnEffect : CardMovingChoiceEffect<ICard>
{
    private readonly bool ownMana;

    public ManaBurnEffect(
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
            ZoneType.Graveyard)
    {
        this.ownMana = ownMana;
    }

    private ManaBurnEffect(ManaBurnEffect effect) : base(effect)
    {
        ownMana = effect.ownMana;
    }

    public override IOneShotEffect Copy()
    {
        return new ManaBurnEffect(this);
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
