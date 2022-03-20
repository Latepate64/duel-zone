using Common;

namespace Cards.Cards.DM03
{
    class ManaNexus : Spell
    {
        public ManaNexus() : base("Mana Nexus", 4, Civilization.Nature)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.FromManaZoneToShieldsFaceDownEffect());
        }
    }
}
