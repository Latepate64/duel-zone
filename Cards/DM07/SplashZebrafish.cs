using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM07
{
    class SplashZebrafish : Engine.Creature
    {
        public SplashZebrafish() : base("Splash Zebrafish", 4, 3000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
