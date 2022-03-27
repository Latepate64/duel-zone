using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class UnicornFish : Creature
    {
        public UnicornFish() : base("Unicorn Fish", 4, 1000, Common.Subtype.Fish, Common.Civilization.Water)
        {
            AddAbilities(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
