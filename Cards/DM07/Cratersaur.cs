using Abilities.Static;
using ContinuousEffects;
using Interfaces;

namespace Cards.DM07;

internal sealed class Cratersaur : Creature
{
    internal Cratersaur(PowerAttackerAbilityFactory abilityFactory)
        : base("Cratersaur", 3, 2000, Race.RockBeast, Civilization.Fire)
    {
        AddStaticAbilities(
            new WhileYouHaveNoShieldsThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect(
                3000,
                abilityFactory));
    }
}
