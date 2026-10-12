using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM05;

sealed class ScissorScarab : Creature
{
    public ScissorScarab() : base("Scissor Scarab", 7, 5000, Race.GiantInsect,
        Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new SearchEffect(
                    reveal: true,
                    filter: new RaceCreatureFilter(Race.GiantInsect)
        )));
    }
}