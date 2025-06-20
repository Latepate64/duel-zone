using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public class DiscardAnyNumberOfCardsEffect : ChooseAnyNumberOfCardsEffect
{
    public DiscardAnyNumberOfCardsEffect() : base()
    {
    }

    public DiscardAnyNumberOfCardsEffect(ChooseAnyNumberOfCardsEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DiscardAnyNumberOfCardsEffect(this);
    }

    public override string ToString()
    {
        return "Discard any number of cards from your hand.";
    }

    protected override void Apply(IGame game, IAbility source, params Card[] cards)
    {
        Controller.Discard(source, game, cards);
    }

    protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Hand.Cards;
    }
}
