using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class MechadragonsBreath : Spell
{
    public MechadragonsBreath() : base("Mechadragon's Breath", 6, Civilization.Fire)
    {
        AddSpellAbilities(new MechadragonsBreathEffect());
    }
}
