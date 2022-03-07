using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class EmergencyTyphoonEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            new ControllerMayDrawCardsEffect(2).Apply(game, source);
            new DiscardEffect(new CardFilters.OwnersHandCardFilter(), 1, 1, true).Apply(game, source);
        }

        public override OneShotEffect Copy()
        {
            return new EmergencyTyphoonEffect();
        }

        public override string ToString()
        {
            return "Draw up to 2 cards.Then discard a card from your hand.";
        }
    }
}