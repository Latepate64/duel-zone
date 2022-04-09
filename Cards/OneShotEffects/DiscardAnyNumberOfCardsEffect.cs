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

        public override IOneShotEffect Copy()
        {
            return new DiscardAnyNumberOfCardsEffect();
        }

        public override string ToString()
        {
            return "Discard any number of cards from your hand.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            source.GetController(game).Discard(game, cards);
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.GetPlayer(source.Source).Hand.Cards;
        }
    }
}
