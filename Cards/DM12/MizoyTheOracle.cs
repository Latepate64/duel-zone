using TriggeredAbilities;

namespace Cards.DM12
{
    sealed class MizoyTheOracle : Engine.Creature
    {
        public MizoyTheOracle() : base("Mizoy, the Oracle", 3, 2500, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect()));
        }
    }
}
