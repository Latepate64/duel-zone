using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class MoonlightFlash : Spell
{
    public MoonlightFlash() : base("Moonlight Flash", 4, Civilization.Light)
    {
        AddSpellAbilities(
            new TapChoiceEffect(
                    minimum: 0,
                    maximum: 2,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                ));
    }
}