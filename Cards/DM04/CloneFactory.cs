using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

sealed class CloneFactory : Spell
{
    public CloneFactory() : base("Clone Factory", 3, Civilization.Water)
    {
        AddSpellAbilities(
            new ManaRecoveryEffect(
                minimum: 0,
                maximum: 2,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}