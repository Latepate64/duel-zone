using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class CraniumClamp : Spell
{
    public CraniumClamp() : base("Cranium Clamp", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 2,
                maximum: 2,
                controllerChooses: false,
                filter: new AnyCardFilter(),
                source: ZoneType.Hand,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCreatures
        ));
    }
}