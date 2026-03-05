using ContinuousEffects;
using Interfaces;

namespace Cards.DM11;

public sealed class AsraVizierOfSafety : WaveStrikerCreature
{
    public AsraVizierOfSafety() : base("Asra, Vizier of Safety", 3, 2000, Race.Initiate, Civilization.Light)
    {
        AddWaveStrikerAbility(new AsraVizierOfSafetyEffect());
    }
}
