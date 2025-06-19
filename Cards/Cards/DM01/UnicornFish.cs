using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class UnicornFish : Creature
    {
        public UnicornFish() : base("Unicorn Fish", 4, 1000, Engine.Race.Fish, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
