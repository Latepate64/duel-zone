using ContinuousEffects;
using Interfaces;

namespace Cards.DM08;

public sealed class SashaChannelerOfSuns : Creature
{
    public SashaChannelerOfSuns() : base("Sasha, Channeler of Suns", 8, 9500, Race.MechaDelSol, Civilization.Light)
    {
        AddStaticAbilities(new SashaBlockerEffect(), new SashaPowerEffect());
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
