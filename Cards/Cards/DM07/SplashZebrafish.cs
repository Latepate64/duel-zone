using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM07
{
    class SplashZebrafish : Engine.Creature
    {
        public SplashZebrafish() : base("Splash Zebrafish", 4, 3000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
