using Common;

namespace Cards.Cards.DM07
{
    class RomVizierOfTendrils : Creature
    {
        public RomVizierOfTendrils() : base("Rom, Vizier of Tendrils", 4, 2000, Subtype.Initiate, Civilization.Light)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
