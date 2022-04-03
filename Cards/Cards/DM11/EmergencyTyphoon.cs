using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM11
{
    class EmergencyTyphoon : Spell
    {
        public EmergencyTyphoon() : base("Emergency Typhoon", 2, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DrawThenDiscardEffect(1));
        }
    }
}
