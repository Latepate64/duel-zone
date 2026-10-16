using Abilities;
using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07;

public sealed class GandarSeekerOfExplosions : Creature
{
    public GandarSeekerOfExplosions() : base("Gandar, Seeker of Explosions", 7,
        6500, Race.MechaThunder, Civilization.Light)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddAbilities(
            new TapAbility(
                new AtTheEndOfTurnEffect(
                    new AtTheEndOfTheTurnDelayedTriggeredAbilityFactory(),
                    new UntapAreaOfEffect(
                        new CivilizationCreatureFilter(Civilization.Light),
                        SelectionRange.OwnCards
                    )
                )));
    }
}
