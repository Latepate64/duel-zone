namespace Cards.DM03
{
    class BoomerangComet : Charger
    {
        public BoomerangComet() : base("Boomerang Comet", 6, Interfaces.Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
        }
    }
}
