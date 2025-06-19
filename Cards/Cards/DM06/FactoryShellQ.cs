using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class FactoryShellQ : Engine.Creature
    {
        public FactoryShellQ() : base("Factory Shell Q", 6, 2000, [Engine.Race.Survivor, Engine.Race.ColonyBeetle], Engine.Civilization.Nature)
        {
            AddStaticAbilities(new SurvivorEffect(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new OneShotEffects.SearchRaceCreatureEffect(Engine.Race.Survivor))));
        }
    }
}
