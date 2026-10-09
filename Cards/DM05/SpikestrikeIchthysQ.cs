using Abilities.Static;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.Unblockable;

namespace Cards.DM05
{
    sealed class SpikestrikeIchthysQ : Creature
    {
        public SpikestrikeIchthysQ() : base("Spikestrike Ichthys Q", 6, 3000, [Interfaces.Race.Survivor, Interfaces.Race.Fish], Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(new ThisCreatureCannotBeBlockedEffect())));
        }
    }
}
