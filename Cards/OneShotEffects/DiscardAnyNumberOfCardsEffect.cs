using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class DiscardAnyNumberOfCardsEffect : ChooseAnyNumberOfCardsEffect
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

        protected override void Apply(IAbility source, params ICard[] cards)
        {
            Applier.Discard(source, cards);
        }

        protected override IEnumerable<ICard> GetAffectedCards(IAbility source)
        {
            return Applier.Hand.Cards;
        }
    }
}
