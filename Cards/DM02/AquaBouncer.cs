using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM02
{
    sealed class AquaBouncer : Creature
    {
        public AquaBouncer() : base("Aqua Bouncer", 6, 1000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
