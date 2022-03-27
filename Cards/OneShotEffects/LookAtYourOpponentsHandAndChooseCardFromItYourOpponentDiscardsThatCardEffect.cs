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
            source.GetController(game).Look(source.GetOpponent(game), game, source.GetOpponent(game).Hand.Cards.ToArray());
            var cards = source.GetController(game).Choose(new BoundedCardSelectionInEffect(source.GetController(game).Id, source.GetOpponent(game).Hand.Cards, 1, 1, ToString()), game).Decision.Select(x => game.GetCard(x)).ToArray();
            source.GetOpponent(game).Discard(game, cards);
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