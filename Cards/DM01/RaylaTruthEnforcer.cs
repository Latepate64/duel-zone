using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class RaylaTruthEnforcer : Creature
{
    public RaylaTruthEnforcer() : base("Rayla, Truth Enforcer", 6, 3000,
        Race.Berserker, Civilization.Light)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new SearchEffect(
                    reveal: true,
                    filter: new SpellFilter()
        )));
    }
}