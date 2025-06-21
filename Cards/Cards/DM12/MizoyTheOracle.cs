using TriggeredAbilities;

namespace Cards.Cards.DM12
{
    class MizoyTheOracle : Engine.Creature
    {
        public MizoyTheOracle() : base("Mizoy, the Oracle", 3, 2500, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect()));
        }
    }
}
