using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class EmergencyTyphoon : Spell
    {
        public EmergencyTyphoon() : base("Emergency Typhoon", 2, Civilization.Water)
        {
            ShieldTrigger = true;
            AddAbilities(new SpellAbility(new EmergencyTyphoonEffect()));
        }
    }

    class EmergencyTyphoonEffect : OneShotEffect
    {
        public override object Apply(Game game, Ability source)
        {
            foreach (var effect in new OneShotEffect[] { new ControllerMayDrawCardsEffect(2), new DiscardEffect(new CardFilters.OwnersHandCardFilter(), 1, 1, true) })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new EmergencyTyphoonEffect();
        }

        public override string ToString()
        {
            return "Draw up to 2 cards. Then discard a card from your hand.";
        }
    }
}
