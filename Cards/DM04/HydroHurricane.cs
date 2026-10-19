using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class HydroHurricane : Spell
{
    public HydroHurricane() : base("Hydro Hurricane", 6, Civilization.Water)
    {
        AddSpellAbilities(
            new HydroHurricaneFirstEffect(),
            new HydroHurricaneSecondEffect(
                ownFilter: new CivilizationCreatureFilter(
                    Civilization.Darkness),
                opponentFilter: new CreatureFilter()
            ));
    }
}
