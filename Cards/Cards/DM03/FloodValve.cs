namespace Cards.Cards.DM03
{
    class FloodValve : Spell
    {
        public FloodValve() : base("Flood Valve", 2, Common.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnCardsFromYourManaZoneToYourHandEffect(1));
        }
    }
}
