using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class ForbosSanctumGuardianQ : Creature
{
    public ForbosSanctumGuardianQ() : base("Forbos, Sanctum Guardian Q", 6,
        4000, [Race.Survivor, Race.Guardian], Civilization.Light)
    {
        AddStaticAbilities(
            new SurvivorEffect(
                new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                    new SearchEffect(
                        reveal: true,
                        filter: new SpellFilter()
        ))));
    }
}