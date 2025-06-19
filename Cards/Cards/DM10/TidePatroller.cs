using Cards.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class TidePatroller : Engine.Creature
    {
        public TidePatroller() : base("Tide Patroller", 4, 2000, Engine.Race.Merfolk, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
