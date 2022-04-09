using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class SpikestrikeIchthysQ : Creature
    {
        public SpikestrikeIchthysQ() : base("Spikestrike Ichthys Q", 6, 3000, Subtype.Survivor, Subtype.Fish, Civilization.Water)
        {
            AddSurvivorAbility(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
