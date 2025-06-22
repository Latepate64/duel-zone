using Engine;
using Interfaces;

namespace Cards.DM12;

public sealed class MechadragonsBreath : Spell
{
    public MechadragonsBreath() : base("Mechadragon's Breath", 6, Civilization.Fire)
    {
        AddSpellAbilities(new MechadragonsBreathEffect());
    }
}
