namespace Cards.Cards.DM03
{
    class ManaNexus : Spell
    {
        public ManaNexus() : base("Mana Nexus", 4, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.FromManaZoneToShieldsFaceDownEffect());
        }
    }
}
