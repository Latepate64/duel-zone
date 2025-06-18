namespace Cards.Cards.DM03
{
    class FloodValve : Engine.Spell
    {
        public FloodValve() : base("Flood Valve", 2, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
        }
    }
}
