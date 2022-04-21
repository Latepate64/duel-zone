using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YourOpponentChoosesCardsInHisManaZoneAndPutsThemIntoHisGraveyardEffect : ManaBurnEffect
    {
        private readonly int _amount;

        public YourOpponentChoosesCardsInHisManaZoneAndPutsThemIntoHisGraveyardEffect(int amount) : base(amount, amount, false)
        {
            _amount = amount;
        }

        public YourOpponentChoosesCardsInHisManaZoneAndPutsThemIntoHisGraveyardEffect(YourOpponentChoosesCardsInHisManaZoneAndPutsThemIntoHisGraveyardEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override IOneShotEffect Copy()
        {
            return new YourOpponentChoosesCardsInHisManaZoneAndPutsThemIntoHisGraveyardEffect(this);
        }

        public override string ToString()
        {
            return $"Your opponent chooses {(_amount > 1 ? $"{_amount} cards" : "a card")} in his mana zone and puts {(_amount > 1 ? "them" : "it")} into his graveyard.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return GetOpponent(game).ManaZone.Cards;
        }
    }
}
