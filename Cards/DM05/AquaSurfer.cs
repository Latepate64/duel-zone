using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM05
{
    class AquaSurfer : Engine.Creature
    {
        public AquaSurfer() : base("Aqua Surfer", 6, 2000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
