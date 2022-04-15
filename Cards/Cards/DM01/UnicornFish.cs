using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class UnicornFish : Creature
    {
        public UnicornFish() : base("Unicorn Fish", 4, 1000, Engine.Subtype.Fish, Common.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
