using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class LagunaLightningEnforcer : Creature
{
    public LagunaLightningEnforcer() : base("Laguna, Lightning Enforcer", 5,
        2500, Race.Berserker, Civilization.Light)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new SearchEffect(
                    reveal: true,
                    filter: new SpellFilter()
        )));
    }
}