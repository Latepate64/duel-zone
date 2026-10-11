using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM04;

public sealed class ChainsOfSacrifice : Spell
{
    public ChainsOfSacrifice() : base("Chains of Sacrifice", 8,
        Civilization.Darkness)
    {
        AddSpellAbilities(
            new DestroyEffect(
                minimum: 0,
                maximum: 2,
                controllerChooses: true,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.OpponentsCreatures
            ),
            new DestroyEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.OwnCreatures
            ));
    }
}
