using Abilities.Static;
using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;

namespace Cards.DM11;

public sealed class AsraVizierOfSafety : WaveStrikerCreature
{
    public AsraVizierOfSafety(
        BlockerAbilityFactory blockerAbilityFactory
    ) : base("Asra, Vizier of Safety", 3, 2000, Race.Initiate, Civilization.Light)
    {
        AddWaveStrikerAbility(
            new ThisCreatureGetsPowerAndAbilityEffect(
                4000,
                blockerAbilityFactory.Create()
        ));
    }
}
