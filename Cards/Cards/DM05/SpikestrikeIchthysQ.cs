using Common;

namespace Cards.Cards.DM05
{
    class SpikestrikeIchthysQ : Creature
    {
        public SpikestrikeIchthysQ() : base("Spikestrike Ichthys Q", 6, 3000, Civilization.Water)
        {
            AddSubtypes(Subtype.Survivor, Subtype.Fish);
            AddAbilities(new StaticAbilities.SurvivorAbility(new StaticAbilities.UnblockableAbility()));
        }
    }
}
