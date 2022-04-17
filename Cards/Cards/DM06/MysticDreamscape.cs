namespace Cards.Cards.DM06
{
    class MysticDreamscape : Spell
    {
        public MysticDreamscape() : base("Mystic Dreamscape", 4, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnUpToCardsFromYourManaZoneToYourHandEffect(3));
        }
    }
}
