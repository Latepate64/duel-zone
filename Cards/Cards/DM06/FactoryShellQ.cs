using Common;

namespace Cards.Cards.DM06
{
    class FactoryShellQ : Creature
    {
        public FactoryShellQ() : base("Factory Shell Q", 6, 2000, Civilization.Nature)
        {
            AddSubtypes(Subtype.Survivor, Subtype.ColonyBeetle);
            AddAbilities(new StaticAbilities.SurvivorAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchSubtypeCreatureEffect(Subtype.Survivor))));
        }
    }
}
