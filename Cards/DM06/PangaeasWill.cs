using Engine;
using Interfaces;

namespace Cards.DM06;

public class PangaeasWill : Spell
{
    public PangaeasWill() : base("Pangaea's Will", 3, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(new PangaeasWillEffect());
    }
}
