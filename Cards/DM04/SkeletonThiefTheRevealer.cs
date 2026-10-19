using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM04;

sealed class SkeletonThiefTheRevealer : Creature
{
    public SkeletonThiefTheRevealer() : base("Skeleton Thief, the Revealer", 4,
        2000, Race.LivingDead, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new RaceCreatureFilter(Race.LivingDead),
                    source: ZoneType.Graveyard,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCards
        )));
    }
}