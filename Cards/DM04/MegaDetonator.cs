using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class MegaDetonator : Spell
{
    public MegaDetonator() : base("Mega Detonator", 2, Civilization.Fire)
    {
        AddSpellAbilities(new MegaDetonatorDiscardEffect());
    }
}
