using Engine;
using Interfaces;

namespace Cards.DM08;

public class Dracobarrier : Spell
{
    public Dracobarrier() : base("Dracobarrier", 3, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new DracobarrierEffect());
    }
}
