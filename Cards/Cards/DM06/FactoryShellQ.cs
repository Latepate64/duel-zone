using Common;

namespace Cards.Cards.DM06
{
    class FactoryShellQ : Creature
    {
        public FactoryShellQ() : base("Factory Shell Q", 6, 2000, Engine.Subtype.Survivor, Engine.Subtype.ColonyBeetle, Civilization.Nature)
        {
            AddSurvivorAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchSubtypeCreatureEffect(Engine.Subtype.Survivor)));
        }
    }
}
