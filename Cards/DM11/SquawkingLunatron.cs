namespace Cards.DM11
{
    class SquawkingLunatron : SilentSkillCreature
    {
        public SquawkingLunatron() : base("Squawking Lunatron", 5, 4000, Interfaces.Race.CyberMoon, Interfaces.Civilization.Water)
        {
            AddSilentSkillAbility(new OneShotEffects.ReturnUpToThreeCardsFromYourManaZoneToYourHandEffect());
        }
    }
}
