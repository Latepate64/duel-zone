using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class DiscardCardFromYourHandEffect : DiscardEffect
    {
        public DiscardCardFromYourHandEffect() : base(new CardFilters.OwnersHandCardFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DiscardCardFromYourHandEffect();
        }

        public override string ToString()
        {
            return "Discard a card from your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).Hand.Cards;
        }
    }
}
