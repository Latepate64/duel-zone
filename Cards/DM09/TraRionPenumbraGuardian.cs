using OneShotEffects;
using Abilities;
using Interfaces;
using CardFilters;

namespace Cards.DM09;

public sealed class TraRionPenumbraGuardian : Creature
{
    public TraRionPenumbraGuardian() : base("Tra Rion, Penumbra Guardian", 6,
        5500, Race.Guardian, Civilization.Light)
    {
        AddAbilities(
            new TapAbility(
                new TraRionPenumbraGuardianEffect(
                    new RaceCreatureFilterFactory(),
                    new AtTheEndOfTheTurnDelayedTriggeredAbilityFactory()
                )));
    }
}
