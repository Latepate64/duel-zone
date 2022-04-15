namespace Cards.Cards.DM06
{
    class ArmoredDecimatorValkaizer : EvolutionCreature
    {
        public ArmoredDecimatorValkaizer() : base("Armored Decimator Valkaizer", 5, 5000, Engine.Subtype.Human, Engine.Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(4000));
        }
    }
}
