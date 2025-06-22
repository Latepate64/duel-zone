using ContinuousEffects;

namespace Cards.DM01
{
    sealed class KingCoral : Engine.Creature
    {
        public KingCoral() : base("King Coral", 3, 1000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
