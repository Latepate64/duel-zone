using ContinuousEffects;
using Interfaces;

namespace Cards.DM12;

public sealed class FeverNuts : Creature
{
    public FeverNuts() : base("Fever Nuts", 3, 1000, Race.WildVeggies, Civilization.Nature)
    {
        AddStaticAbilities(new FeverNutsEffect());
    }
}
