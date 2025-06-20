using ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class SpikestrikeIchthysQ : Engine.Creature
    {
        public SpikestrikeIchthysQ() : base("Spikestrike Ichthys Q", 6, 3000, [Engine.Race.Survivor, Engine.Race.Fish], Engine.Civilization.Water)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureCannotBeBlockedEffect())));
        }
    }
}
