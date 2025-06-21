using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM04
{
    class DoboulgyserGiantRockBeast : EvolutionCreature
    {
        public DoboulgyserGiantRockBeast() : base("Doboulgyser, Giant Rock Beast", 6, 8000, Interfaces.Race.RockBeast, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000)));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
