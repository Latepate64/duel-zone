using Engine;
using Interfaces;

namespace Cards.DM10;

public class RapidReincarnation : Spell
{
    public RapidReincarnation() : base("Rapid Reincarnation", 3, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(new RapidReincarnationEffect());
    }
}
