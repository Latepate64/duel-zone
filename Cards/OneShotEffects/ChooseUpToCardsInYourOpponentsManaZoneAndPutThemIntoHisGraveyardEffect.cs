using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseUpToCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect : ManaBurnEffect
    {
        private readonly int _amount;

        public ChooseUpToCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect(int amount) : base(new CardFilters.OpponentsManaZoneCardFilter(), 0, amount, true)
        {
            _amount = amount;
        }

        public ChooseUpToCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect(ChooseUpToCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseUpToCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect(this);
        }

        public override string ToString()
        {
            return $"Choose up to {_amount} cards in your opponent's mana zone and put them into his graveyard.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetOpponent(game).ManaZone.Cards;
        }
    }
}
