using ContinuousEffects;
using Interfaces;

namespace Cards.DM12;

public sealed class KilstineNebulaElemental : WaveStrikerCreature
{
    public KilstineNebulaElemental() : base(
        "Kilstine, Nebula Elemental", 7, 5000, Race.AngelCommand, Civilization.Light)
    {
        AddWaveStrikerAbility(new KilstineNebulaElementalEffect());
    }
}
