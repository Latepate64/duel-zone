using Engine;
using Interfaces;

namespace Cards.DM03;

public sealed class EldritchPoison : Spell
{
    public EldritchPoison() : base("Eldritch Poison", 1, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(new EldritchPoisonEffect());
    }
}
