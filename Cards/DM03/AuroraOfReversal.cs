using Engine;
using Interfaces;

namespace Cards.DM03;

public class AuroraOfReversal : Spell
{
    public AuroraOfReversal() : base("Aurora of Reversal", 5, Civilization.Nature)
    {
        AddSpellAbilities(new AuroraOfReversalEffect());
    }
}
