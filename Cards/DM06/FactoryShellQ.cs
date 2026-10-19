using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM06;

sealed class FactoryShellQ : Creature
{
    public FactoryShellQ() : base("Factory Shell Q", 6, 2000, [Race.Survivor,
        Race.ColonyBeetle], Civilization.Nature)
    {
        AddStaticAbilities(
            new SurvivorEffect(
                new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                    new SearchEffect(
                    reveal: true,
                    filter: new RaceCreatureFilter(Race.Survivor)
        ))));
    }
}