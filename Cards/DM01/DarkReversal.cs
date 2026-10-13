using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class DarkReversal : Spell
{
    public DarkReversal() : base("Dark Reversal", 2, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.Graveyard,
                destination: ZoneType.Hand,
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}