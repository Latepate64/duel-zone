using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class MarineScramble : Spell
{
    public MarineScramble() : base("Marine Scramble", 7, Civilization.Water)
    {
        AddSpellAbilities(new MarineScrambleEffect());
    }
}
