using Cards.ContinuousEffects;
using Cards.OneShotEffects;

namespace Cards.Cards.DM02
{
    class AquaBouncer : Creature
    {
        public AquaBouncer() : base("Aqua Bouncer", 6, 1000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
