using Common;

namespace Cards.Cards.DM04
{
    class ExplodingCactus : Creature
    {
        public ExplodingCactus() : base("Exploding Cactus", 3, 2000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.WhileYouControlCivilizationCreatureThisCreatureGetsPowerAbility(Civilization.Light, 2000));
        }
    }
}
