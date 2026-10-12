using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

sealed class HawkeyeLunatron : Creature
{
    public HawkeyeLunatron() : base("Hawkeye Lunatron", 8, 6000, Race.CyberMoon,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new SearchEffect(
                    reveal: false,
                    filter: new AnyCardFilter()
        )));
    }
}