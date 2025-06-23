namespace Cards.DM03
{
    sealed class FloodValve : Spell
    {
        public FloodValve() : base("Flood Valve", 2, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
        }
    }
}
