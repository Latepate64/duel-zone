using Interfaces;

namespace OneShotEffects;

public sealed class ManaBurnEffect : CardMovingChoiceEffect<ICard>
{
    private readonly ICardFilter filter;
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
            ZoneType.ManaZone,
            ZoneType.Graveyard)
    {
        this.filter = filter;
        this.ownMana = ownMana;
    }

    private ManaBurnEffect(ManaBurnEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
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
