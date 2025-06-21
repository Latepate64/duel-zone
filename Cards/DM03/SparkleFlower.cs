using ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Interfaces;

namespace Cards.DM03
{
    class SparkleFlower : Creature
    {
        public SparkleFlower() : base("Sparkle Flower", 4, 3000, Race.StarlightTree, Civilization.Light)
        {
            AddStaticAbilities(new SparkleFlowerEffect());
        }
    }

    class SparkleFlowerEffect : ContinuousEffect, IBlockerEffect
    {
        public SparkleFlowerEffect() : base()
        {
        }

        public bool CanBlock(ICreature blocker, ICreature attacker, IGame game)
        {
            return IsSourceOfAbility(blocker) && Ability.Controller.ManaZone.AreAllCivilizationCards(Civilization.Light);
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
