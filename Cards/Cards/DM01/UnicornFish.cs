using TriggeredAbilities;
using OneShotEffects;

namespace Cards.Cards.DM01
{
    class UnicornFish : Engine.Creature
    {
        public UnicornFish() : base("Unicorn Fish", 4, 1000, Engine.Race.Fish, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
