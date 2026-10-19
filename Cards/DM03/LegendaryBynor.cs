using StaticAbilities;
using ContinuousEffects.Unblockable;
using Interfaces;
using CardFilters;

namespace Cards.DM03;

public sealed class LegendaryBynor : EvolutionCreature
{
    public LegendaryBynor() : base("Legendary Bynor", 6, 8000, Race.Leviathan, Civilization.Water)
    {
        AddStaticAbilities(
            new YourOtherCreaturesCannotBeBlockedEffect(
                attackerFilter: new CivilizationCreatureFilter(Civilization.Water),
                blockerFilter: new CreatureFilter()));
        AddAbilities(new DoubleBreakerAbility());
    }
}
