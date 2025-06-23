using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class FluorogillManta : Creature
{
    public FluorogillManta() : base("Fluorogill Manta", 6, 1000, Race.GelFish, Civilization.Water)
    {
        AddStaticAbilities(new FluorogillMantaEffect());
    }
}
