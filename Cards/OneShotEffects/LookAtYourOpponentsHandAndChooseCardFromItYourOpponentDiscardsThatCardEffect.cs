using Common.Choices;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Owner);
            if (player != null)
            {
                var opponent = game.GetOpponent(player);
                if (opponent != null)
                {
                    player.Look(opponent, game, opponent.Hand.Cards.ToArray());
                    var cards = player.Choose(new BoundedCardSelectionInEffect(player.Id, opponent.Hand.Cards, 1, 1, ToString()), game).Decision.Select(x => game.GetCard(x)).ToArray();
                    opponent.Discard(cards, game);
                    opponent.Unreveal(cards);
                    return cards;
                }
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect();
        }

        public override string ToString()
        {
            return "Look at your opponent's hand and choose a card from it. Your opponent discards that card.";
        }
    }
}