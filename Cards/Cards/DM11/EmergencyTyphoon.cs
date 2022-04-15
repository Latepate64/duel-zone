using Cards.OneShotEffects;

namespace Cards.Cards.DM11
{
    class EmergencyTyphoon : Spell
    {
        public EmergencyTyphoon() : base("Emergency Typhoon", 2, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DrawThenDiscardEffect(1));
        }
    }
}
