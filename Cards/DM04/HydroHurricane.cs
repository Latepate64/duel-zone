using Engine;
using Interfaces;

namespace Cards.DM04;

public class HydroHurricane : Spell
{
    public HydroHurricane() : base("Hydro Hurricane", 6, Civilization.Water)
    {
        AddSpellAbilities(new HydroHurricaneFirstEffect(), new HydroHurricaneSecondEffect());
    }
}
