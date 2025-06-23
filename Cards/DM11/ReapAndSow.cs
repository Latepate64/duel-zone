using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class ReapAndSow : Spell
{
    public ReapAndSow() : base("Reap and Sow", 5, Civilization.Fire, Civilization.Nature)
    {
        AddSpellAbilities(new ReapAndSowEffect());
    }
}
