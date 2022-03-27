﻿using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YourOpponentChoosesAndDiscardsCardsFromHisHandEffect : DiscardEffect
    {
        private readonly int _amount;

        public YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(int amount) : base(new CardFilters.OpponentsHandCardFilter(), amount, amount, false)
        {
            _amount = amount;
        }

        public YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(YourOpponentChoosesAndDiscardsCardsFromHisHandEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override IOneShotEffect Copy()
        {
            return new YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(this);
        }

        public override string ToString()
        {
            return $"Your opponent chooses and discards {(_amount > 1 ? $"{_amount} cards" : "a card")} from his hand.";
        }
    }
}