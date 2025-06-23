using ContinuousEffects;

namespace Cards.DM04
{
    sealed class ExplodingCactus : Creature
    {
        public ExplodingCactus() : base("Exploding Cactus", 3, 2000, Interfaces.Race.TreeFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(2000, Interfaces.Civilization.Light));
        }
    }
}
