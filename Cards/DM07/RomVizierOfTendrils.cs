using TriggeredAbilities;

namespace Cards.DM07
{
    sealed class RomVizierOfTendrils : Engine.Creature
    {
        public RomVizierOfTendrils() : base("Rom, Vizier of Tendrils", 4, 2000, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
