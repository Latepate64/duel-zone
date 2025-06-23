namespace Cards.DM03
{
    sealed class ManaNexus : Spell
    {
        public ManaNexus() : base("Mana Nexus", 4, Interfaces.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.FromManaZoneToShieldsFaceDownEffect());
        }
    }
}
