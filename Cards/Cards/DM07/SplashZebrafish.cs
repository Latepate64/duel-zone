using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM07
{
    class SplashZebrafish : Creature
    {
        public SplashZebrafish() : base("Splash Zebrafish", 4, 3000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
