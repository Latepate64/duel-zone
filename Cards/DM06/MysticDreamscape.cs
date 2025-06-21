namespace Cards.DM06
{
    class MysticDreamscape : Engine.Spell
    {
        public MysticDreamscape() : base("Mystic Dreamscape", 4, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnUpToThreeCardsFromYourManaZoneToYourHandEffect());
        }
    }
}
