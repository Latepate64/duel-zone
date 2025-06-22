using Engine;
using Interfaces;

namespace Cards.DM07;

public class JusticeJamming : Spell
{
    public JusticeJamming() : base("Justice Jamming", 3, Civilization.Light)
    {
        AddSpellAbilities(new JusticeJammingEffect());
    }
}
