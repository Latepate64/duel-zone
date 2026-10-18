using StaticAbilities;
using CardFilters;
using ContinuousEffects.CannotAttack;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class ThrashCrawler : Creature
{
    public ThrashCrawler() : base("Thrash Crawler", 4, 5000, Race.EarthEater, Civilization.Water)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    source: ZoneType.ManaZone,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCards
        )));
        AddStaticAbilities(new ThisCreatureCannotAttackEffect());
    }
}