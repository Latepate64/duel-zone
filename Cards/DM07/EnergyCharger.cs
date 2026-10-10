using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class EnergyCharger : Charger
{
    public EnergyCharger() : base("Energy Charger", 3, Civilization.Fire)
    {
        AddSpellAbilities(
            new OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(
                2000, new CreatureFilter()));
    }
}