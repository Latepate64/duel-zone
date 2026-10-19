using Interfaces;

namespace OneShotEffects;

public sealed class LookEffect : CardSelectionEffect<ICard>
{
    public LookEffect(int minimum, int maximum) : base(minimum, maximum, true)
    {
    }

    private LookEffect(LookEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new LookEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICard[] cards)
    {
        if (cards.Length != 0)
        {
            var revealer = game.GetOwner(cards.First());
            Controller.Look(revealer, game, cards);
            revealer.Unreveal(cards);
        }
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        return Applier.Opponent.ShieldZone.Cards;
    }
}
