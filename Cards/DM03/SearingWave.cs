using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class SearingWave : Spell
{
    public SearingWave() : base("Searing Wave", 5, Civilization.Fire)
    {
        AddSpellAbilities(
            new SearingWaveEffect(),
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                source: ZoneType.ShieldZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OwnCards
        ));
    }
}
