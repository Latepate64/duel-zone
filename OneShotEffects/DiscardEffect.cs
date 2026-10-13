using Interfaces;

namespace OneShotEffects;

public sealed class DiscardEffect : CardMovingChoiceEffect
{
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
            filter,
            ZoneType.Hand,
            ZoneType.Graveyard)
    {
        this.ownHand = ownHand;
    }

    private DiscardEffect(DiscardEffect effect) : base(effect)
    {
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
