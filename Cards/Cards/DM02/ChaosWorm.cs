namespace Cards.Cards.DM02
{
    class ChaosWorm : EvolutionCreature
    {
        public ChaosWorm() : base("Chaos Worm", 5, 5000, Engine.Subtype.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesEffect());
        }
    }
}
