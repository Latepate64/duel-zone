using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    public class GhastlyDrainEffect : ChooseAnyNumberOfCardsEffect
    {
        public GhastlyDrainEffect() : base(new CardFilters.OwnersShieldZoneCardFilter())
        {
        }

        public GhastlyDrainEffect(ChooseAnyNumberOfCardsEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new GhastlyDrainEffect();
        }

        public override string ToString()
        {
            return "Choose any number of your shields and put them into your hand. You can't use the \"shield trigger\" abilities of those shields.";
        }

        protected override void Apply(Game game, Ability source, IEnumerable<Card> cards)
        {
            game.PutFromShieldZoneToHand(cards.ToArray(), false);
        }
    }
}
