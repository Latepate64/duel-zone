using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12;

sealed class MizoyTheOracle : Creature
{
    public MizoyTheOracle() : base("Mizoy, the Oracle", 3, 2500,
        Race.LightBringer, Civilization.Light)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ChooseAndTapCreaturesEffect(
                    0, 1, new CivilizationCreatureFilter(
                        Civilization.Darkness, Civilization.Fire)
                )));
    }
}