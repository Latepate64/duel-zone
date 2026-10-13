using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM04;

public sealed class ChainsOfSacrifice : Spell
{
    public ChainsOfSacrifice() : base("Chains of Sacrifice", 8,
        Civilization.Darkness)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 0,
                maximum: 2,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCreatures
            ),
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OwnCreatures
            ));
    }
}
