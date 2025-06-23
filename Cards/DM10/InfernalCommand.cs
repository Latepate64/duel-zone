using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class InfernalCommand : Spell
{
    public InfernalCommand() : base("Infernal Command", 1, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(new InfernalCommandEffect());
    }
}
