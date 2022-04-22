using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect : OneShotEffect
    {
        public LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect()
        {
        }

        public LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            Controller.Look(GetOpponent(game), game, GetOpponent(game).Hand.Cards.ToArray());
            var card = Controller.ChooseCard(GetOpponent(game).Hand.Cards, ToString());
            if (card != null)
            {
                GetOpponent(game).Discard(Ability, game, card);
                GetOpponent(game).Unreveal(new List<ICard>() { card });
            }
        }

        public override IOneShotEffect Copy()
        {
            return new LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect(this);
        }

        public override string ToString()
        {
            return "Look at your opponent's hand and choose a card from it. Your opponent discards that card.";
        }
    }
}