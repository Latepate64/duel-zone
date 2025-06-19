using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;
using Effects.Continuous;

namespace Cards.Cards.DM04
{
    class DoboulgyserGiantRockBeast : EvolutionCreature
    {
        public DoboulgyserGiantRockBeast() : base("Doboulgyser, Giant Rock Beast", 6, 8000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000)));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
