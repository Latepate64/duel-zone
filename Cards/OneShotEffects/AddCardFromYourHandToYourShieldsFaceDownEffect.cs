using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class AddCardFromYourHandToYourShieldsFaceDownEffect : ShieldAdditionEffect
    {
        public AddCardFromYourHandToYourShieldsFaceDownEffect() : base(1, 1, true)
        {
        }

        public AddCardFromYourHandToYourShieldsFaceDownEffect(ShieldAdditionEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new AddCardFromYourHandToYourShieldsFaceDownEffect(this);
        }

        public override string ToString()
        {
            return "Add a card from your hand to your shields face down.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Applier.Hand.Cards;
        }
    }
}
