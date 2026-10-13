using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

sealed class MorbidMedicine : Spell
{
    public MorbidMedicine() : base("Morbid Medicine", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 0,
                maximum: 2,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.Graveyard,
                destination: ZoneType.Hand,
                selectionRange: SelectionRange.OwnCards
        ));
    }
}