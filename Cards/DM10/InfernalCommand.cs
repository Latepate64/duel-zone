using Engine;
using Interfaces;

namespace Cards.DM10;

public class InfernalCommand : Spell
{
    public InfernalCommand() : base("Infernal Command", 1, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(new InfernalCommandEffect());
    }
}
