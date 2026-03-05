using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class Dracobarrier : Spell
{
    public Dracobarrier() : base("Dracobarrier", 3, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new DracobarrierEffect());
    }
}
