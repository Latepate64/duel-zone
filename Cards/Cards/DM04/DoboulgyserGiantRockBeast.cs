using Common;

namespace Cards.Cards.DM04
{
    class DoboulgyserGiantRockBeast : EvolutionCreature
    {
        public DoboulgyserGiantRockBeast() : base("Doboulgyser, Giant Rock Beast", 6, 8000, Engine.Subtype.RockBeast, Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000));
            AddDoubleBreakerAbility();
        }
    }
}
