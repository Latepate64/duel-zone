using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class MiraculousSnare : Spell
{
    public MiraculousSnare() : base("Miraculous Snare", 3, Civilization.Light,
        Civilization.Water)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new NonEvolutionCreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.ShieldZone,
                selectionRange: SelectionRange.AllCards
            ));
    }
}
