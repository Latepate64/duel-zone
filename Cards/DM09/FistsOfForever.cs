using Engine;
using Interfaces;

namespace Cards.DM09;

public class FistsOfForever : Spell
{
    public FistsOfForever() : base("Fists of Forever", 1, Civilization.Fire)
    {
        AddSpellAbilities(new FistsOfForeverEffect());
    }
}
