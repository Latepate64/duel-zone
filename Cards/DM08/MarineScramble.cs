using Engine;
using Interfaces;

namespace Cards.DM08;

public class MarineScramble : Spell
{
    public MarineScramble() : base("Marine Scramble", 7, Civilization.Water)
    {
        AddSpellAbilities(new MarineScrambleEffect());
    }
}
