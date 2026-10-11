using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class VacuumGel : Spell
{
    public VacuumGel() : base("Vacuum Gel", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new ChooseAndDestroyOpponentsCreaturesEffect(
                1, 1, new MultiFilter(
                    new UntappedCreatureFilter(),
                    new CivilizationCreatureFilter(
                        Civilization.Light, Civilization.Nature)
                )
            ));
    }
}
