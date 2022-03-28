using Common;

namespace Cards.Cards.DM07
{
    class SplashZebrafish : Creature
    {
        public SplashZebrafish() : base("Splash Zebrafish", 4, 3000, Subtype.GelFish, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
            AddThisCreatureCannotBeBlockedAbility();
        }
    }
}
