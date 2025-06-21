namespace Cards.DM03
{
    class ManaNexus : Engine.Spell
    {
        public ManaNexus() : base("Mana Nexus", 4, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.FromManaZoneToShieldsFaceDownEffect());
        }
    }
}
