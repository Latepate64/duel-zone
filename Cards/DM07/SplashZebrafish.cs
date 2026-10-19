using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07;

sealed class SplashZebrafish : Creature
{
    public SplashZebrafish() : base("Splash Zebrafish", 4, 3000, Race.GelFish,
        Civilization.Water)
    {
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
        AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect(new CreatureFilter()));
    }
}