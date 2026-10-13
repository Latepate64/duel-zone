using Interfaces;

namespace OneShotEffects;

public sealed class DiscardEffect : CardMovingChoiceEffect<ICard>
{
    private readonly ICardFilter filter;
    private readonly bool ownHand; 

    public DiscardEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        ICardFilter filter,
        bool ownHand) : base(
            minimum,
            maximum,
            controllerChooses,
            ZoneType.Hand,
            ZoneType.Graveyard)
    {
        this.filter = filter;
        this.ownHand = ownHand;
    }

    private DiscardEffect(DiscardEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        ownHand = effect.ownHand;
    }

    public override IOneShotEffect Copy()
    {
        return new DiscardEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        if (ownHand)
        {
            return Applier.Hand.Cards;
        }
        else
        {
            return Applier.Opponent.Hand.Cards;
        }
    }
}
