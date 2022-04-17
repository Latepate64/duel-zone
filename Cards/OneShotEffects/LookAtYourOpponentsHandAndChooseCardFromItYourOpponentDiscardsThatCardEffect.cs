using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            source.GetController(game).Look(source.GetOpponent(game), game, source.GetOpponent(game).Hand.Cards.ToArray());
            var card = source.GetController(game).ChooseCard(source.GetOpponent(game).Hand.Cards, ToString());
            source.GetOpponent(game).Discard(source, game, card);
            source.GetOpponent(game).Unreveal(new List<ICard>() { card });
            return card;
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