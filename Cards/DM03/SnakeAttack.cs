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
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                source: ZoneType.ShieldZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}
