using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// While all the cards in your mana zone are light cards, this creature has
/// \"Blocker\".
/// </summary>
public sealed class SparkleFlowerEffect : ContinuousEffect, IAbilityAddingEffect
{
    public SparkleFlowerEffect() : base()
    {
    }

    public SparkleFlowerEffect(SparkleFlowerEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new SparkleFlowerEffect(this);
    }

    public void AddAbility(IGame game)
    {
        if (Source!.OwnerV2.ManaZone.AreAllCivilizationCards(
            Civilization.Light))
        {
            game.AddAbility(Source, new BlockerAbility());
        }
    }
}
