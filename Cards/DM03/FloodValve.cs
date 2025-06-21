namespace Cards.DM03
{
    class FloodValve : Engine.Spell
    {
        public FloodValve() : base("Flood Valve", 2, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
        }
    }
}
