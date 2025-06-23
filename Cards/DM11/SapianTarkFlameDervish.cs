using Interfaces;

namespace Cards.DM11;

public sealed class SapianTarkFlameDervish : WaveStrikerCreature
{
    public SapianTarkFlameDervish() : base("Sapian Tark, Flame Dervish", 3, 2000, Race.Dragonoid, Civilization.Fire)
    {
        AddWaveStrikerAbility(new SapianTarkFlameDervishEffect());
    }
}
