namespace Cards.DM06
{
    sealed class MysticDreamscape : Engine.Spell
    {
        public MysticDreamscape() : base("Mystic Dreamscape", 4, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.ReturnUpToThreeCardsFromYourManaZoneToYourHandEffect());
        }
    }
}
