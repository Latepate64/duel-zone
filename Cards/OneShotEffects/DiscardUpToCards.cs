using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class DiscardUpToCards : DiscardEffect
    {
        public DiscardUpToCards(int maximum) : base(0, maximum, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DiscardUpToCards(Maximum);
        }

        public override string ToString()
        {
            return Maximum == 1 ? "You may discard a card." : $"You may discard up to {Maximum} cards.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).Hand.Cards;
        }
    }
}