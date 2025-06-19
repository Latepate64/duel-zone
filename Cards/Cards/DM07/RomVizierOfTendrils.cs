using Cards.TriggeredAbilities;

namespace Cards.Cards.DM07
{
    class RomVizierOfTendrils : Creature
    {
        public RomVizierOfTendrils() : base("Rom, Vizier of Tendrils", 4, 2000, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
