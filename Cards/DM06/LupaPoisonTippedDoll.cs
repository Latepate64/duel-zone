using Abilities;
using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class LupaPoisonTippedDoll : Creature
{
    public LupaPoisonTippedDoll() : base("Lupa, Poison-Tipped Doll", 2, 1000,
        Race.DeathPuppet, Civilization.Darkness)
    {
        AddAbilities(
            new TapAbility(
                new OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
                    new SlayerAbility(),
                    new CreatureFilter()
                )));
    }
}