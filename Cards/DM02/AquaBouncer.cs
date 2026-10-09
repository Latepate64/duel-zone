using TriggeredAbilities;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM02
{
    sealed class AquaBouncer : Creature
    {
        public AquaBouncer() : base("Aqua Bouncer", 6, 1000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
