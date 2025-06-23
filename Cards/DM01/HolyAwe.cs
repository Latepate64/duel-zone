using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class HolyAwe : Spell
{
    public HolyAwe() : base("Holy Awe", 6, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new HolyAweEffect());
    }
}
