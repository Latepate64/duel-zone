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
                new ChooseAndTapCreaturesEffect(
                    0, 1, new CivilizationCreatureFilter(
                        Civilization.Darkness, Civilization.Fire)
                )));
    }
}