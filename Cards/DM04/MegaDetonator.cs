using Engine;
using Interfaces;

namespace Cards.DM04;

public class MegaDetonator : Spell
{
    public MegaDetonator() : base("Mega Detonator", 2, Civilization.Fire)
    {
        AddSpellAbilities(new MegaDetonatorDiscardEffect());
    }
}
