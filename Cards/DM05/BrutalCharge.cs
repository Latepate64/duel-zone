using Engine;
using Interfaces;

namespace Cards.DM05;

public class BrutalCharge : Spell
{
    public BrutalCharge() : base("Brutal Charge", 2, Civilization.Nature)
    {
        AddSpellAbilities(new BrutalChargeEffect());
    }
}
