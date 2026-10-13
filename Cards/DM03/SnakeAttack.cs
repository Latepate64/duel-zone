using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM03;

public sealed class SnakeAttack : Spell
{
    public SnakeAttack() : base("Snake Attack", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new SnakeAttackEffect(),
            new ShieldBurnEffect(
                minimum: 1,
                maximum: 1,
                filter: new AnyCardFilter(),
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}
