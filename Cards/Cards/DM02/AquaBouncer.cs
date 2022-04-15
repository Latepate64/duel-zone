using Cards.OneShotEffects;

namespace Cards.Cards.DM02
{
    class AquaBouncer : Creature
    {
        public AquaBouncer() : base("Aqua Bouncer", 6, 1000, Engine.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            AddBlockerAbility();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
