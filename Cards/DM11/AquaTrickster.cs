using TriggeredAbilities;

namespace Cards.DM11
{
    sealed class AquaTrickster : WaveStrikerCreature
    {
        public AquaTrickster() : base("Aqua Trickster", 2, 1000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
        }
    }
}
