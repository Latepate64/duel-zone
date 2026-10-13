using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

sealed class KaratePotato : Creature
{
    public KaratePotato() : base("Karate Potato", 4, 1000, Race.WildVeggies,
        Civilization.Nature)
    {
        AddShieldTrigger();
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 2,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    source: ZoneType.Hand,
                    destination: ZoneType.ManaZone
        )));
    }
}
