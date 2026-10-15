using OneShotEffects;
using Abilities;
using Interfaces;
using CardFilters;
using TriggeredAbilities;

namespace Cards.DM09;

public sealed class TraRionPenumbraGuardian : Creature
{
    public TraRionPenumbraGuardian() : base("Tra Rion, Penumbra Guardian", 6,
        5500, Race.Guardian, Civilization.Light)
    {
        AddAbilities(
            new TapAbility(
                new TraRionPenumbraGuardianEffect(
                    factory: new RaceCreatureFilterFactory(),
                    delayedTrigger: new AtTheEndOfTheTurnDelayedTriggeredAbility()
                )));
    }
}