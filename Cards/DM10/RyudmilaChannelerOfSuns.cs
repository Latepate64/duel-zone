using CardFilters;
using ContinuousEffects.PowerModifying;
using ContinuousEffects.Replacement;
using Interfaces;

namespace Cards.DM10;

public sealed class RyudmilaChannelerOfSuns : Creature
{
    public RyudmilaChannelerOfSuns() : base("Ryudmila, Channeler of Suns", 5,
        2000, Race.MechaDelSol, Civilization.Light)
    {
        AddStaticAbilities(
            new ThisCreatureGetsPowerForEachOfYourOtherCreatures(
                2000, new UntappedCreatureFilter()),
            new RyudmilaChannelerOfSunsEffect());
    }
}
