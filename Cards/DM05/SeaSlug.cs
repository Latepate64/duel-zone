using ContinuousEffects;

namespace Cards.DM05
{
    sealed class SeaSlug : Engine.Creature
    {
        public SeaSlug() : base("Sea Slug", 8, 6000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
