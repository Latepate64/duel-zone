namespace Cards.Cards.DM04
{
    class DoboulgyserGiantRockBeast : EvolutionCreature
    {
        public DoboulgyserGiantRockBeast() : base("Doboulgyser, Giant Rock Beast", 6, 8000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000));
            AddDoubleBreakerAbility();
        }
    }
}
