using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12;

sealed class PharziTheOracle : Creature
{
    public PharziTheOracle() : base("Pharzi, the Oracle", 2, 1000,
        Race.LightBringer, Civilization.Light)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new SalvageEffect(
                    minimum: 0,
                    maximum: 1,
                    filter: new SpellFilter(),
                    excludeSource: false,
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}