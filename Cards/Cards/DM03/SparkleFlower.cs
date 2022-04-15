using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM03
{
    class SparkleFlower : Creature
    {
        public SparkleFlower() : base("Sparkle Flower", 4, 3000, Subtype.StarlightTree, Civilization.Light)
        {
            AddStaticAbilities(new SparkleFlowerEffect());
        }
    }

    class SparkleFlowerEffect : ContinuousEffect, IBlockerEffect
    {
        public SparkleFlowerEffect() : base()
        {
        }

        public bool Applies(ICard blocker, ICard attacker, IGame game)
        {
            return IsSourceOfAbility(blocker, game) && GetSourceAbility(game).GetController(game).ManaZone.Cards.All(x => x.HasCivilization(Civilization.Light));
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
