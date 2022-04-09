using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class AddCardFromYourHandToYourShieldsFaceDownEffect : ShieldAdditionEffect
    {
        public AddCardFromYourHandToYourShieldsFaceDownEffect() : base(new CardFilters.OwnersHandCardFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new AddCardFromYourHandToYourShieldsFaceDownEffect();
        }

        public override string ToString()
        {
            return "Add a card from your hand to your shields face down.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.GetPlayer(source.Controller).Hand.Cards;
        }
    }
}
