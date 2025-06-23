using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class RapidReincarnation : Spell
{
    public RapidReincarnation() : base("Rapid Reincarnation", 3, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new RapidReincarnationEffect());
    }
}
