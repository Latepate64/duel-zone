using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM05;

sealed class LeQuistTheOracle : Creature
{
    public LeQuistTheOracle() : base("Le Quist, the Oracle", 2, 1500,
        Race.LightBringer, Civilization.Light)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new TapChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    ownerChooses: true,
                    filter: new CivilizationCreatureFilter(
                        Civilization.Darkness, Civilization.Fire),
                    selectionRange: SelectionRange.AllCreatures
                )));
    }
}