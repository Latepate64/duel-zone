using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class EnergyCharger : Charger
{
    public EnergyCharger() : base("Energy Charger", 3, Civilization.Fire)
    {
        AddSpellAbilities(
            new AddChosenCreatureAffectingNumberEffect(
                2000,
                new CreatureFilter(),
                new CreaturesGetPowerEffectFactory(),
                new UntilEndOfThisTurnDuration()));
    }
}