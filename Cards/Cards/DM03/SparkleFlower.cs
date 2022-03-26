using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class SparkleFlower : Creature
    {
        public SparkleFlower() : base("Sparkle Flower", 4, 3000, Subtype.StarlightTree, Civilization.Light)
        {
            AddAbilities(new SparkleFlowerAbility());
        }
    }

    class SparkleFlowerAbility : Engine.Abilities.StaticAbility
    {
        public SparkleFlowerAbility() : base(new SparkleFlowerEffect())
        {
        }
    }

    class SparkleFlowerEffect : BlockerEffect
    {
        public SparkleFlowerEffect() : base(new Engine.TargetFilter(), new CardFilters.OpponentsBattleZoneCreatureFilter(), new Durations.Indefinite(), new Conditions.AllOfCivilizationCondition(Civilization.Light))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SparkleFlowerEffect();
        }

        public override string ToString()
        {
            return "While all the cards in your mana zone are light cards, this creature has \"Blocker\".";
        }
    }
}
