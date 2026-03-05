using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

public sealed class JusticeJamming : Spell
{
    public JusticeJamming() : base("Justice Jamming", 3, Civilization.Light)
    {
        AddSpellAbilities(new JusticeJammingEffect());
    }
}
