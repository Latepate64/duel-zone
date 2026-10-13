using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class MidnightCrawler : Creature
{
    public MidnightCrawler() : base("Midnight Crawler", 8, 6000,
        Race.EarthEater, Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaRecoveryEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}