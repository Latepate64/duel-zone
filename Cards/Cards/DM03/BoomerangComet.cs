namespace Cards.Cards.DM03
{
    class BoomerangComet : Charger
    {
        public BoomerangComet() : base("Boomerang Comet", 6, Engine.Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
        }
    }
}
