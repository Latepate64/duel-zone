using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect : OneShotEffect
    {
        public LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect()
        {
        }

        public LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var cards = Applier.LookAtTheTopCardsOfYourDeck(4, game);
            var card = Applier.ChooseCard(cards, ToString());
            game.Move(Ability, ZoneType.Deck, ZoneType.Hand, card);
            Applier.PutOnTheBottomOfDeckInAnyOrder(cards.Where(x => x != card).ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect(this);
        }

        public override string ToString()
        {
            return "Look at the top 4 cards of your deck. Put one of them into your hand, and put the rest on the bottom of your deck in any order.";
        }
    }
}
