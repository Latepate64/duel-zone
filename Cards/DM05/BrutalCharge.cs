using Interfaces;
using OneShotEffects;

namespace Cards.DM05;

public sealed class BrutalCharge : Spell
{
    public BrutalCharge() : base("Brutal Charge", 2, Civilization.Nature)
    {
        AddSpellAbilities(new BrutalChargeEffect());
    }
}
