using Engine;
using Interfaces;

namespace Cards.DM04;

public sealed class ScreamingSunburst : Spell
{
    public ScreamingSunburst() : base("Screaming Sunburst", 3, Civilization.Light)
    {
        AddSpellAbilities(new ScreamingSunburstEffect());
    }
}
