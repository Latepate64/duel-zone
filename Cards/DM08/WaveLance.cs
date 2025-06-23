using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class WaveLance : Spell
{
    public WaveLance() : base("Wave Lance", 3, Civilization.Water)
    {
        AddSpellAbilities(new WaveLanceEffect());
    }
}
