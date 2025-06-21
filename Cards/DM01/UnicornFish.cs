using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    class UnicornFish : Engine.Creature
    {
        public UnicornFish() : base("Unicorn Fish", 4, 1000, Interfaces.Race.Fish, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
