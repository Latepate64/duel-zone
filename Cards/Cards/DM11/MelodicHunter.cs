using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM11
{
    class MelodicHunter : Engine.Creature
    {
        public MelodicHunter() : base("Melodic Hunter", 5, 3000, Engine.Race.Merfolk, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
