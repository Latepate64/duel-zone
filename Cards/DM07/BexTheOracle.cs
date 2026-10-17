using Abilities.Static;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM07;

public sealed class BexTheOracle : Creature
{
    public BexTheOracle(BlockerAbilityFactory blockerAbilityFactory) : base(
        "Bex, the Oracle", 3, 2500, Race.LightBringer, Civilization.Light)
    {
        AddStaticAbilities(
            new WhileYouHaveNoShieldsThisCreatureHasAbilityEffect(
                blockerAbilityFactory
            ));
    }
}
