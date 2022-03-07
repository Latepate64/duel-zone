using Common;

namespace Cards.Cards.DM11
{
    class EmergencyTyphoon : Spell
    {
        public EmergencyTyphoon() : base("Emergency Typhoon", 2, Civilization.Water)
        {
            ShieldTrigger = true;
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.EmergencyTyphoonEffect()));
        }
    }
}
