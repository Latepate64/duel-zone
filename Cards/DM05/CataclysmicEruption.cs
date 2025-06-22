using Engine;
using Interfaces;

namespace Cards.DM05;

public sealed class CataclysmicEruption : Spell
{
    public CataclysmicEruption() : base("Cataclysmic Eruption", 8, Civilization.Fire)
    {
        AddSpellAbilities(new CataclysmicEruptionEffect());
    }
}
