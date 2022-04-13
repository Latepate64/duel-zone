using Common;

namespace Cards.Cards.DM06
{
    class FactoryShellQ : Creature
    {
        public FactoryShellQ() : base("Factory Shell Q", 6, 2000, Subtype.Survivor, Subtype.ColonyBeetle, Civilization.Nature)
        {
            AddSurvivorAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchSubtypeCreatureEffect(Subtype.Survivor)));
        }
    }
}
