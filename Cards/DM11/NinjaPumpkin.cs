using ContinuousEffects;
using Interfaces;

namespace Cards.DM11;

public sealed class NinjaPumpkin : WaveStrikerCreature
{
    public NinjaPumpkin() : base("Ninja Pumpkin", 3, 2000, Race.WildVeggies, Civilization.Nature)
    {
        AddWaveStrikerAbility(new NinjaPumpkinEffect());
    }
}
