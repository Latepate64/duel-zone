using ContinuousEffects;

namespace Cards.DM11
{
    sealed class MelodicHunter : Creature
    {
        public MelodicHunter() : base("Melodic Hunter", 5, 3000, Interfaces.Race.Merfolk, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
