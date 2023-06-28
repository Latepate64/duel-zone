using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect : OneShotEffect
    {
        private readonly int _amount;

        protected LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect(int amount)
        {
            _amount = amount;
        }

        protected LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect(LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override void Apply(IGame game)
        {
            var cards = Applier.LookAtTheTopCardsOfYourDeck(_amount);
            Applier.ArrangeTopCardsOfDeck(cards.ToArray());
        }

        public override string ToString()
        {
            return $"Look at up to {_amount} cards from the top of your deck and put them back in any order.";
        }
    }
}
