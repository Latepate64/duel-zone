using TriggeredAbilities;
using OneShotEffects;
using ContinuousEffects;

namespace Cards.DM02
{
    class AquaBouncer : Engine.Creature
    {
        public AquaBouncer() : base("Aqua Bouncer", 6, 1000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
