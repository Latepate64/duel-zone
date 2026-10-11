using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class DeathSmoke : Spell
{
    public DeathSmoke() : base("Death Smoke", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new DestroyEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new UntappedCreatureFilter(),
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}
