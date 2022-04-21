using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class DiscardCardFromYourHandEffect : DiscardEffect
    {
        public DiscardCardFromYourHandEffect() : base(1, 1, true)
        {
        }

        public DiscardCardFromYourHandEffect(DiscardEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DiscardCardFromYourHandEffect(this);
        }

        public override string ToString()
        {
            return "Discard a card from your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return GetController(game).Hand.Cards;
        }
    }
}
