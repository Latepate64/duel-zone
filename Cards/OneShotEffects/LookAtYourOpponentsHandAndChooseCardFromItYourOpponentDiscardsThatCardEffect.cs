using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            source.GetController(game).Look(source.GetOpponent(game), game, source.GetOpponent(game).Hand.Cards.ToArray());
            var cards = source.GetController(game).ChooseCards(source.GetOpponent(game).Hand.Cards, 1, 1, ToString());
            source.GetOpponent(game).Discard(game, cards.ToArray());
            source.GetOpponent(game).Unreveal(cards);
            return cards;
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