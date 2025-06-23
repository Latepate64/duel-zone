using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class RyudmilaChannelerOfSuns : Creature
{
    public RyudmilaChannelerOfSuns() : base(
        "Ryudmila, Channeler of Suns", 5, 2000, Race.MechaDelSol, Civilization.Light)
    {
        AddStaticAbilities(
            new ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(2000), new RyudmilaChannelerOfSunsEffect());
    }
}
