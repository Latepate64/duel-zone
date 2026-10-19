using StaticAbilities;
using ContinuousEffects.Unblockable;
using CardFilters;

namespace Cards.DM05
{
    sealed class SpikestrikeIchthysQ : Creature
    {
        public SpikestrikeIchthysQ() : base("Spikestrike Ichthys Q", 6, 3000, [Interfaces.Race.Survivor, Interfaces.Race.Fish], Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureCannotBeBlockedEffect(new CreatureFilter()))));
        }
    }
}
