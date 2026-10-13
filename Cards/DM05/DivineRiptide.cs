using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM05;

public sealed class DivineRiptide : Spell
{
    public DivineRiptide() : base("Divine Riptide", 9, Civilization.Water)
    {
        AddSpellAbilities(
            new ManaRecoveryAreaOfEffect(
                filter: new AnyCardFilter(),
                selectionRange: SelectionRange.AllCreatures
            ));
    }
}
