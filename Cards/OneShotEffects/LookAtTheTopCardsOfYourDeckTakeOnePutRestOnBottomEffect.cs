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

        public override void Apply(IGame game, IAbility source)
        {
            var cards = GetController(game).LookAtTheTopCardsOfYourDeck(4, game);
            var card = GetController(game).ChooseCard(cards, ToString());
            game.Move(source, ZoneType.Deck, ZoneType.Hand, card);
            GetController(game).PutOnTheBottomOfDeckInAnyOrder(cards.Where(x => x != card).ToArray());
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
