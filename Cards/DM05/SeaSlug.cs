using Abilities.Static;
using ContinuousEffects.Unblockable;

namespace Cards.DM05
{
    sealed class SeaSlug : Creature
    {
        public SeaSlug() : base("Sea Slug", 8, 6000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
