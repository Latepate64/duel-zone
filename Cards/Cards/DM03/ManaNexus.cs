using Common;

namespace Cards.Cards.DM03
{
    class ManaNexus : Spell
    {
        public ManaNexus() : base("Mana Nexus", 4, Civilization.Nature)
        {
            ShieldTrigger = true;
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.FromManaZoneToShieldsFaceDownEffect()));
        }
    }
}
