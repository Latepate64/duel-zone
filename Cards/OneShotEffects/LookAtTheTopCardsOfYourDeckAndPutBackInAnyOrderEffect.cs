﻿using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect : OneShotEffect
    {
        private readonly int _amount;

        public LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect(int amount)
        {
            _amount = amount;
        }

        public LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect(LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override object Apply(IGame game, IAbility source)
        {
            var cards = source.GetController(game).LookAtTheTopCardsOfYourDeck(_amount, game);
            source.GetController(game).ArrangeTopCardsOfDeck(cards.ToArray());
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect(this);
        }

        public override string ToString()
        {
            return $"Look at up to {_amount} cards from the top of your deck and put them back in any order.";
        }
    }
}
