using Engine;
using Interfaces;

namespace Cards.DM11;

public class ReapAndSow : Spell
{
    public ReapAndSow() : base("Reap and Sow", 5, Civilization.Fire, Civilization.Nature)
    {
        AddSpellAbilities(new ReapAndSowEffect());
    }
}
