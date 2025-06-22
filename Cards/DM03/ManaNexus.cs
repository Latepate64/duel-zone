namespace Cards.DM03
{
    sealed class ManaNexus : Engine.Spell
    {
        public ManaNexus() : base("Mana Nexus", 4, Interfaces.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.FromManaZoneToShieldsFaceDownEffect());
        }
    }
}
