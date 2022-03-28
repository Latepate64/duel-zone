using Cards.OneShotEffects;

namespace Cards.Cards.DM05
{
    class AquaSurfer : Creature
    {
        public AquaSurfer() : base("Aqua Surfer", 6, 2000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            ShieldTrigger = true;
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
