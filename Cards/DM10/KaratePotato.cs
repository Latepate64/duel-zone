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
                new YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(
                    minimum: 0,
                    maximum: 2,
                    filter: new AnyCardFilter()
        )));
    }
}
