namespace Cards.Cards.DM10
{
    class HawkeyeLunatron : Creature
    {
        public HawkeyeLunatron() : base("Hawkeye Lunatron", 8, 6000, Engine.Subtype.CyberMoon, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchCardNoRevealEffect());
        }
    }
}
