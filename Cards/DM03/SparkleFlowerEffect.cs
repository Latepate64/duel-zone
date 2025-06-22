using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM03;

public sealed class SparkleFlowerEffect : ContinuousEffect, IBlockerEffect
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
