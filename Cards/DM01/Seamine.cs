using ContinuousEffects;

namespace Cards.DM01
{
    sealed class Seamine : Creature
    {
        public Seamine() : base("Seamine", 6, 4000, Interfaces.Race.Fish, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
