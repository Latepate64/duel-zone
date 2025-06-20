using ContinuousEffects;

namespace Cards.Cards.DM05
{
    class SeaSlug : Engine.Creature
    {
        public SeaSlug() : base("Sea Slug", 8, 6000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
