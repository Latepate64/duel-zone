using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class CrimsonHammer : Spell
{
    public CrimsonHammer() : base("Crimson Hammer", 2, Civilization.Fire)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MaxPowerFilter(2000),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}