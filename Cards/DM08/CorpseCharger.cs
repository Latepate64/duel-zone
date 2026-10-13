using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

sealed class CorpseCharger : Charger
{
    public CorpseCharger() : base("Corpse Charger", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new SalvageEffect(
                minimum: 1,
                maximum: 1,
                filter: new CreatureFilter(),
                excludeSource: false,
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}