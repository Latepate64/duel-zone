using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect : ManaBurnEffect
    {
        public ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect() : base(new CardFilters.OpponentsManaZoneCardFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect();
        }

        public override string ToString()
        {
            return "Choose a card in your opponent's mana zone and put it into his graveyard.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetOpponent(game).ManaZone.Cards;
        }
    }
}
