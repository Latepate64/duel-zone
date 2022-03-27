namespace Cards.Cards.DM03
{
    class FloodValve : Spell
    {
        public FloodValve() : base("Flood Valve", 2, Common.Civilization.Water)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.ReturnCardsFromYourManaZoneToYourHandEffect(1));
        }
    }
}
