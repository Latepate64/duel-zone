using Cards.OneShotEffects;

namespace Cards.Cards.DM05
{
    class AquaSurfer : Creature
    {
        public AquaSurfer() : base("Aqua Surfer", 6, 2000, Engine.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
