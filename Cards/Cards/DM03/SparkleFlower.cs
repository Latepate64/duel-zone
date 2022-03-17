using Common;

namespace Cards.Cards.DM03
{
    class SparkleFlower : Creature
    {
        public SparkleFlower() : base("Sparkle Flower", 4, 3000, Subtype.StarlightTree, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(new Conditions.AllOfCivilizationCondition(Civilization.Light)));
        }
    }
}
