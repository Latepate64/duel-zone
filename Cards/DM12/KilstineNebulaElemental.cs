using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;

namespace Cards.DM12;

public sealed class KilstineNebulaElemental : WaveStrikerCreature
{
    public KilstineNebulaElemental(
        CreatureFilter creatureFilter,
        BlockerAbilityFactory blockerAbilityFactory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory
    ) : base(
        "Kilstine, Nebula Elemental", 7, 5000, Race.AngelCommand, Civilization.Light)
    {
        AddWaveStrikerAbility(
            new EachOfYourCreaturesGetsPowerAndAbilitiesEffect(
                creatureFilter,
                5000,
                blockerAbilityFactory.Create(),
                doubleBreakerAbilityFactory.Create()
            ));
    }
}
