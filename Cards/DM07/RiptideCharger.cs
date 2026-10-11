using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class RiptideCharger : Charger
{
    public RiptideCharger() : base("Riptide Charger", 5, Civilization.Water)
    {
        AddSpellAbilities(
            new ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
                1, 1, new CreatureFilter()
            ));
    }
}