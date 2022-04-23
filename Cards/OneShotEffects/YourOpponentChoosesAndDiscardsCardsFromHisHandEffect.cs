using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    abstract class YourOpponentChoosesAndDiscardsCardsFromHisHandEffect : DiscardEffect
    {
        private readonly int _amount;

        protected YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(int amount) : base(amount, amount, false)
        {
            _amount = amount;
        }

        protected YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(YourOpponentChoosesAndDiscardsCardsFromHisHandEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override string ToString()
        {
            return $"Your opponent chooses and discards {(_amount > 1 ? $"{_amount} cards" : "a card")} from his hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return GetOpponent(game).Hand.Cards;
        }
    }
}
