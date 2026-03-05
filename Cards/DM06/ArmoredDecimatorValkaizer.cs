using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class ArmoredDecimatorValkaizer : EvolutionCreature
    {
        public ArmoredDecimatorValkaizer() : base("Armored Decimator Valkaizer", 5, 5000, Interfaces.Race.Human, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(4000)));
        }
    }
}
