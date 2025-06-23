using ContinuousEffects;
using Interfaces;

namespace Cards.DM10;

public sealed class GlaisMejiculaTheExtreme : EvolutionCreature
{
    public GlaisMejiculaTheExtreme() : base("Glais Mejicula, the Extreme", 2, 5500, Race.Initiate, Civilization.Light)
    {
        AddStaticAbilities(new GlaisMejiculaEffect());
    }
}
