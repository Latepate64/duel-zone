using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class Teleportation : Spell
{
    public Teleportation() : base("Teleportation", 5, Civilization.Water)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 0,
                maximum: 2,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.Hand,
                selectionRange: SelectionRange.AllCreatures
        ));
    }
}