using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class HourglassMutant : Creature
{
    public HourglassMutant() : base("Hourglass Mutant", 3, 2000, Race.Hedrian, Civilization.Darkness)
    {
        AddStaticAbilities(new HourglassMutantEffect());
    }
}
