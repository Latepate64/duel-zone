using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class DeathSmoke : Spell
{
    public DeathSmoke() : base("Death Smoke", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new UntappedCreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCards
            ));
    }
}
