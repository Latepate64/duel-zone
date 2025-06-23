using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    sealed class UnicornFish : Creature
    {
        public UnicornFish() : base("Unicorn Fish", 4, 1000, Interfaces.Race.Fish, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
