using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM05;

public sealed class EnchantedSoil : Spell
{
    public EnchantedSoil() : base("Enchanted Soil", 4, Civilization.Nature)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 0,
                maximum: 2,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.Graveyard,
                destination: ZoneType.ManaZone,
                selectionRange: SelectionRange.OwnCards
        ));
    }
}
