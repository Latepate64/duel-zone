using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM03;

public sealed class SparkleFlower : Creature
{
    public SparkleFlower(BlockerAbilityFactory blockerAbilityFactory) : base(
        "Sparkle Flower", 4, 3000, Race.StarlightTree, Civilization.Light)
    {
        AddStaticAbilities(
            new ThisCreatureHasAbilityWhileYourManaCardsAreCivilizationEffect(
                Civilization.Light,
                blockerAbilityFactory.Create()
            ));
    }
}
