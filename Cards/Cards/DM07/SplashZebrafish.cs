namespace Cards.Cards.DM07
{
    class SplashZebrafish : Creature
    {
        public SplashZebrafish() : base("Splash Zebrafish", 4, 3000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
            AddThisCreatureCannotBeBlockedAbility();
        }
    }
}
