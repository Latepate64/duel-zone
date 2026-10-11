using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

sealed class AbductionCharger : Charger
{
    public AbductionCharger() : base("Abduction Charger", 7, Civilization.Water)
    {
        AddSpellAbilities(
            new ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
                0, 2, new CreatureFilter()
            ));
    }
}