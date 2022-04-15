namespace Cards.Cards.DM11
{
    class SquawkingLunatron : SilentSkillCreature
    {
        public SquawkingLunatron() : base("Squawking Lunatron", 5, 4000, Engine.Subtype.CyberMoon, Engine.Civilization.Water)
        {
            AddSilentSkillAbility(new OneShotEffects.ReturnUpToCardsFromYourManaZoneToYourHandEffect(3));
        }
    }
}
