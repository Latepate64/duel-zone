using ContinuousEffects;
using Interfaces;

namespace Cards.DM08;

public sealed class NarielTheOracle : Creature
{
    public NarielTheOracle() : base("Nariel, the Oracle", 4, 1000, Race.LightBringer, Civilization.Light)
    {
        AddStaticAbilities(new NarielTheOracleEffect());
    }
}
