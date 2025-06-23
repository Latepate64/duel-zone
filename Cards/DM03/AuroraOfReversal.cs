using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class AuroraOfReversal : Spell
{
    public AuroraOfReversal() : base("Aurora of Reversal", 5, Civilization.Nature)
    {
        AddSpellAbilities(new AuroraOfReversalEffect());
    }
}
