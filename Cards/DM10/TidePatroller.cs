using ContinuousEffects;

namespace Cards.DM10
{
    sealed class TidePatroller : Engine.Creature
    {
        public TidePatroller() : base("Tide Patroller", 4, 2000, Interfaces.Race.Merfolk, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
