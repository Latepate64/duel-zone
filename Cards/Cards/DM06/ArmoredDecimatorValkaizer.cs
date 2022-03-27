using Common;

namespace Cards.Cards.DM06
{
    class ArmoredDecimatorValkaizer : EvolutionCreature
    {
        public ArmoredDecimatorValkaizer() : base("Armored Decimator Valkaizer", 5, 5000, Subtype.Human, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(4000)));
        }
    }
}
