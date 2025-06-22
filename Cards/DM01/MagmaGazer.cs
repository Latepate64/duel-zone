using Engine;
using Interfaces;

namespace Cards.DM01;

public class MagmaGazer : Spell
{
    public MagmaGazer() : base("Magma Gazer", 3, Civilization.Fire)
    {
        AddSpellAbilities(new MagmaGazerEffect());
    }
}
