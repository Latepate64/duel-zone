using ContinuousEffects;
using Interfaces;

namespace Cards.DM11;

public sealed class SalivaWorm : WaveStrikerCreature
{
    public SalivaWorm() : base("Saliva Worm", 3, 2000, Race.ParasiteWorm, Civilization.Darkness)
    {
        AddWaveStrikerAbility(new SalivaWormEffect());
    }
}
