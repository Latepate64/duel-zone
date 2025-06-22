using Engine;
using Interfaces;

namespace Cards.DM05;

public sealed class GlorySnow : Spell
{
    public GlorySnow() : base("Glory Snow", 4, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new GlorySnowEffect());
    }
}
