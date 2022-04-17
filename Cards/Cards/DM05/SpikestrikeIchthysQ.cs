using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class SpikestrikeIchthysQ : Creature
    {
        public SpikestrikeIchthysQ() : base("Spikestrike Ichthys Q", 6, 3000, Engine.Race.Survivor, Engine.Race.Fish, Engine.Civilization.Water)
        {
            AddSurvivorAbility(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
