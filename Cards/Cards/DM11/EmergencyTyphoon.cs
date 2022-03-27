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
            AddSpellAbilities(new EmergencyTyphoonEffect());
        }
    }

    class EmergencyTyphoonEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new YouMayDrawCardsEffect(2), new DiscardCardFromYourHandEffect() })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new EmergencyTyphoonEffect();
        }

        public override string ToString()
        {
            return "Draw up to 2 cards. Then discard a card from your hand.";
        }
    }
}
