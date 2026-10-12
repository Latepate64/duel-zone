using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class RumblingTerahorn : Creature
{
    public RumblingTerahorn() : base("Rumbling Terahorn", 5, 3000,
        Race.HornedBeast, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new SearchEffect(
                    reveal: true,
                    filter: new CreatureFilter()
        )));
    }
}