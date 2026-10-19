using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

sealed class CorpseCharger : Charger
{
    public CorpseCharger() : base("Corpse Charger", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.Graveyard,
                destination: ZoneType.Hand,
                selectionRange: SelectionRange.OwnCards
        ));
    }
}