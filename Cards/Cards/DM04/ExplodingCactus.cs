using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class ExplodingCactus : Creature
    {
        public ExplodingCactus() : base("Exploding Cactus", 3, 2000, Engine.Subtype.TreeFolk, Civilization.Nature)
        {
            AddStaticAbilities(new WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(Civilization.Light, 2000));
        }
    }
}
