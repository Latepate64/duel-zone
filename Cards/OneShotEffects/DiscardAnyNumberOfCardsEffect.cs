using Engine;
using Engine.Abilities;
using System;

namespace Cards.OneShotEffects
{
    class DiscardAnyNumberOfCardsEffect : ChooseAnyNumberOfCardsEffect
    {
        public DiscardAnyNumberOfCardsEffect() : base(new CardFilters.OwnersHandCardFilter())
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
            game.GetPlayer(source.Owner).Discard(cards, game);
        }
    }
}
